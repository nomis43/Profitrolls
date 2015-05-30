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
			foreach(Personnage pers in ListePersonnages)
            {
                if(pers.GetId()==id)
                {
                    ListePersonnages.Remove(pers);
                    break;
                }
            }
            throw new ArgumentOutOfRangeException("le personnage n'existe pas");
		}

		public static Troll AjouterTroll(string nom, int taille, int force)
		{
            Troll troll = new Troll(nom, taille, force, nextId);
            ListePersonnages.Add(troll);
            nextId++;

            return troll;
                      
		}

		public static Chasseur AjouterChasseur(string nom, string fonction)
		{
            Chasseur chasseur = new Chasseur(nom, fonction, nextId);
            ListePersonnages.Add(chasseur);
            nextId++;

            return chasseur;
		}

	}
}

