namespace packTrolls 
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	
    /**
 *   @ Project : Trolls
 *   @ File Name : Facade.cs
 *   @ Date : 13/05/2015
 *   @ Author : Divoux
 */
 
 /* Cette classe applique le design pattern "Fa�ade", c'est une classe utilitaire (c�d que toutes ses op�rations sont static) ; elle a pour fonction de faire l'interface entre d'une part le menu (ou les fichiers de tests) et, d'autre part, votre package m�tier et de normaliser les interactions entre eux ; elle sera plac�e dans votre package m�tier (qui doit s'appeler "packTrolls") contenant vos objets m�tiers (Personnage, Troll, Chasseur, Arme) et vos gestionnaires d'instances 
 */
 
	public class Facade
	{
    //actions
	public static void InitialiserJeuVide(){}
	public static void CreerJeuDEssai(){} //d�crit dans l'�nonc�
	public static Troll AjouterTroll (string nom, int taille, int force){}
    public static Chasseur AjouterChasseur (string nom, string fonction){}
	public static Arme CreerUneArme (int ida, string nom, int puiss){}
	public static void DonnerUneArme (int ida, int idp){} //id de l'arme, id du personnage
	public static void Frapper (int idpAgresseur, int idpVictime){}
	public static void SupprimerPers (int idp){}
	//informations affichables
	public static IEnumerable<string> AfficherArmesDisponibles(){} //toutes les armes cr��es
	public static string AfficherPersonnageDC(int idp){} 
	public static string AfficherPersonnageDD(int idp){}
	public static IEnumerable<string> AfficherTsPersonnagesDC(){} //description courte
	public static IEnumerable<string> AfficherTsPersonnagesDD(){} //description detaill�e
	//pour les tests
	public static IEnumerable<Personnage> ListerTsPersonnages(){} //tous les personnages cr��s
	public static Personnage GetPersonnage (int idp){} // personnage d'identifiant idp
	public static IEnumerable<Arme> ListerTtesArmes(){} // toutes les armes disponibles
	public static Arme GetArme(int ida){} //arme d'identifiant ida
	public static IEnumerable<Arme> GetArmes(int idp){} //liste des armes du personnage d'identifiant idp
	

	
	}
}

