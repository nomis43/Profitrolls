namespace packTrolls 
{
	using System;
	using System.Collections.Generic;
	
	public class Mage : Personnage
	{
		private static string c_type = "Magicien";
		private static int c_force = 5;
		private List<Arme> mesArmes = new List<Arme>();
		
		
		public Mage(int id, string nom) : base(id, nom, Personnage.c_vieNaissance) { }
		
		public override string GetTypePers()
		{
            return Mage.c_type;
		}
		
		public override int GetForce()
		{
            int forceTot = Mage.c_force;
            foreach (Arme a in mesArmes)
            {
                forceTot += a.GetPuissance() / 2;
            }
            return forceTot;
		}
		
		public override IEnumerable<Arme> GetListeArmes()
		{
            return new List<Arme> (this.mesArmes);
		}
		
		public override void SetTypePers(string type)
		{
            Mage.c_type = type;
		}
		
		public static void c_SetForce(int force)
		{
            Mage.c_force = force;
		}
		
		public override string PresentationCourte()
		{
            return string.Format(base.PresentationCourte() + "{0,-10}{1,-6}{2,-6}{3,-16}{3,-8}", Mage.c_type, this.GetForce(), this.GetVie(), "", this.mesArmes.Count);
		}

		public override string PresentationDetail()
		{
            return base.PresentationDetail() + " ; armes : " + this.ListerMesArmes();
		}
		
		public override string ListerMesArmes() {
            string armes = "";
            foreach (Arme a in mesArmes)
            {
                armes += a.GetNom() + " ,";
            }
            return armes;
        }
		
		public override void RecevoirArme(Arme a)
		{
            bool existe = false;
            foreach (Arme arme in mesArmes)
            {
                if(Object.ReferenceEquals(arme, a))
                {
                    existe = true;
                }
            }
            if (!existe)
            {
                this.mesArmes.Add(a);
            }
		}
		
		public bool PossedeArme(string nom) {
			bool res = false;
			foreach (Arme a in mesArmes) {
				if (a.GetNom() == nom) {
					res = true;
					break;
				}
			}
			return res;
		}

        public override void Frapper(Personnage victime) {
			if (this.PossedeArme("mutant")) {
				ICollection<Personnage> ennemis = GetListeEnnemis();
				Random rand = new Random();
				victime.RecevoirCoup(G_Personnage.GetPersonnage(rand.Next(0, ennemis.Count)), this.GetForce());
				this.AjouterEnnemi(victime);
			}
			else {
				base.Frapper(victime);
			}
		}
		
		public override void RecevoirCoup(Personnage agresseur, int force) {
			if(this.PossedeArme("aura")) {
				this.AjouterEnnemi(agresseur);
			}
			else base.RecevoirCoup(agresseur, force);
		}
	}
}