namespace packTrolls
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public abstract class Personnage
	{
		private string nom;

		private int vie = 200;

		private int id;

		protected static int c_vieNaissance = 200;

        private List<Personnage> mesEnnemis;

		public abstract void RecevoirArme(Arme a);

		public virtual void Frapper(Personnage victime)
		{
            victime.RecevoirCoup(this, this.GetForce());
            this.AjouterEnnemi(victime);
		}

		public abstract string GetTypePers();

		public virtual string PresentationCourte()
		{
            return String.Format("{0,-4}{1,-4}", this.id, this.nom);
		}

		public virtual string PresentationDetail()
		{
            return this.PresentationCourte() + "\n ennemis : " + this.GetEnnemis();
		}

		public abstract IEnumerable<Arme> GetListeArmes();

		public virtual int GetId()
		{
            return this.id;
		}

		public virtual string GetNom()
		{
            return this.nom;
		}

		public abstract int GetForce();

        public abstract string ListerMesArmes();

		public virtual int GetVie()
		{
            return this.vie;
		}

		public Personnage(int id, string nom, int vie)
		{
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException("ERREUR: L'id ne peut pas être inférieur à 1");
            }
            else this.id = id;

            if (String.IsNullOrWhiteSpace(nom) || String.IsNullOrEmpty(nom) || !Char.IsLetter(nom[0]))
            {
                throw new ArgumentOutOfRangeException("ERREUR: Nom invalide!");
            }
            else this.nom = nom;

            if (vie < 0)
            {
                throw new ArgumentOutOfRangeException("ERREUR : Impossible de fixer une valeur négative pour vie");
            }
            else this.vie = vie;
            
            this.mesEnnemis = new List<Personnage>();
		}

		public abstract void SetTypePers(string type);

		public virtual void RecevoirCoup(Personnage agresseur, int force)
		{
            this.AjouterEnnemi(agresseur);
            this.vie -= force;
		}

        public string GetEnnemis()
        {
            string ennemis = "";
            foreach(Personnage p in mesEnnemis)
            {
                ennemis += p.nom + " ";
            }
            return ennemis;
        }
		
		public ICollection<Personnage> GetListeEnnemis() {
			return new List<Personnage>(mesEnnemis);
		}

        public static int C_GetVieNaiss()
        {
            return Personnage.c_vieNaissance;
        }
		
        // On test si l'ennemi qu'on veut ajouter n'est pas déjà dans la liste
		public void AjouterEnnemi(Personnage p) {
            if (!this.mesEnnemis.Contains(p))
            {
			    this.mesEnnemis.Add(p);
            }
		}
	}
}