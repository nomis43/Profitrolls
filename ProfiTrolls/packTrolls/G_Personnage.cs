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

	public class G_Personnage
	{
		private static int nextId = 1;

        private static List<Personnage> ListePersonnages = new List<Personnage>();
		
        // renvoie un personnage créé en fonction de son id
		public static Personnage GetPersonnage(int id)
		{
			foreach (Personnage pers in G_Personnage.ListePersonnages)
            {
                if (pers.GetId()==id)
                {
                    return pers;
                }
            }
            throw new ArgumentOutOfRangeException("le personnage n'existe pas");
		}

		public static IEnumerable<Personnage> ListerTsPersonnages()
		{
            return ListePersonnages;
		}

		public static void SupprimerPers(int id)
		{
            bool trouve = false;
            Personnage p;
            if (id >= 0)
            {
                foreach (Personnage pers in ListePersonnages)
                {
                    if (pers.GetId() == id)
                    {
                        trouve = true;
                        for (int i = 0; i < ListePersonnages.Count; i++)
                        {
                            ListePersonnages[i].SupprimerEnnemi(pers);
                        }
                        ListePersonnages.Remove(pers);
                        break;
                    }
                }
                if (trouve == false)
                {
                    throw new ArgumentOutOfRangeException("Le personnage n'existe pas!");
                }
            }
            throw new ArgumentOutOfRangeException("Id invalide");
		}

		public static Troll AjouterTroll(string nom, int taille, int force)
		{
            Troll troll = new Troll(nextId, nom, taille, force);
            ListePersonnages.Add(troll);
            nextId++;

            return troll;
                      
		}

		public static Chasseur AjouterChasseur(string nom, string fonction)
		{
            Chasseur chasseur = new Chasseur(nextId, nom, fonction);
            ListePersonnages.Add(chasseur);
            nextId++;

            return chasseur;
		}

        public static Mage AjouterMage(string nom)
        {
            Mage mage = new Mage(nextId, nom);
            ListePersonnages.Add(mage);
            nextId++;

            return mage;
        }

        // Function permettant de réinitialiser G_Personnage.
        public static void Reset()
        {
            ListePersonnages.Clear();
            nextId = 1;
        }

	}
}

