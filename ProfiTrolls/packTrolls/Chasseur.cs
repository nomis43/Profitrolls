﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil
//     Les modifications apportées à ce fichier seront perdues si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
namespace packTrolls
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class Chasseur : Personnage
	{
		private static string c_type = "Chasseur";

		private string fonction;

		private static int c_force = 20;

        private List<Arme> mesArmes = new List<Arme>();

        /// <summary>
        /// Permet à un chasseur de reçevoir une arme si elle n'est pas déjà équipée par celui-ci
        /// </summary>
        /// <param name="a">Arme</param>
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

		public override string PresentationCourte()
		{
            return string.Format(base.PresentationCourte() + "{0,-10}{1,-6}{2,-6}{3,-16}{4,-8}", Chasseur.c_type, this.GetForce(), this.GetVie(), this.fonction, this.mesArmes.Count);
		}

		public override string PresentationDetail()
		{
            return base.PresentationDetail() + " ; armes : " + this.ListerMesArmes();
		}

		public override IEnumerable<Arme> GetListeArmes()
		{
            return new List<Arme> (this.mesArmes);
		}

        // Fonction utilisée par PresentationDetail. Renvoie une chaine de caractères avec le nom de toutes les armes du chasseur
        public override string ListerMesArmes() {
            string armes = "";
            foreach (Arme a in mesArmes)
            {
                armes += a.GetNom() + " ,";
            }
            return armes;
        }

		public override string GetTypePers()
		{
            return Chasseur.c_type;
		}

		public Chasseur(int id, string nom, string fonction) : base(id, nom, Personnage.c_vieNaissance)
		{
            if (String.IsNullOrWhiteSpace(fonction) || String.IsNullOrEmpty(fonction) || !Char.IsLetter(fonction[0]))
            {
                throw new ArgumentOutOfRangeException("ERREUR: Fonction invalide!");
            }
            else { this.fonction = fonction; }
		}

		public override int GetForce()
		{
            int forceTot = c_force;
            foreach (Arme a in mesArmes)
            {
                forceTot += a.GetPuissance();
            }
            return forceTot;
		}

		public override void SetTypePers(string type)
		{
            Chasseur.c_type = type;
		}

		public virtual string GetFonction()
		{
            return this.fonction;
		}

		public static void c_SetForce(int force)
		{
            Chasseur.c_force = force;
		}

	}
}

