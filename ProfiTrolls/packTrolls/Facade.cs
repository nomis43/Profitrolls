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
	public static void InitialiserJeuVide() {
        G_Personnage.Reset();
        G_Armes.Reset();
    }

	public static void CreerJeuDEssai(){

        Arme epee = G_Armes.CreerUneArme(1, "Ep�e", 20);
        Arme marteau = G_Armes.CreerUneArme(2, "marteau", 10);
        Arme stylo = G_Armes.CreerUneArme(3, "stylo", 2);
        // Arme aura = G_Armes.CreerUneArme(5, "aura", 0);
        // Arme mutant = G_Armes.CreerUneArme(6,"mutant", 0);

        Personnage T1 = G_Personnage.AjouterTroll("T1", 280, 20);
        Personnage T2 = G_Personnage.AjouterTroll("T2", 220, 40);
        Personnage T3 = G_Personnage.AjouterTroll("T3", 315, 60);

        Personnage C1 = G_Personnage.AjouterChasseur("C1", "chef");
        C1.RecevoirArme(epee);
        C1.RecevoirArme(marteau);
        
        Personnage C2 = G_Personnage.AjouterChasseur("C2", "forgeron");
        C2.RecevoirArme(marteau);

        Personnage C3 = G_Personnage.AjouterChasseur("C3", "etudiant");
        C3.RecevoirArme(stylo);

        // Personnage M1 = G_Personnage.AjouterMage("M1");
        // M1.RecevoirArme(aura);
        // M1.RecevoirArme(mutant);
    } //d�crit dans l'�nonc�

	public static Troll AjouterTroll (string nom, int taille, int force){
        Troll t = G_Personnage.AjouterTroll(nom, taille, force);
        return t;
    }

    public static Chasseur AjouterChasseur (string nom, string fonction){
        Chasseur c = G_Personnage.AjouterChasseur(nom, fonction);
        return c;
    }

    public static Mage AjouterMage(string nom)
    {
        return G_Personnage.AjouterMage(nom);
    }

	public static Arme CreerUneArme (int ida, string nom, int puiss){
        Arme a = G_Armes.CreerUneArme(ida, nom, puiss);
        return a;
    }

	public static void DonnerUneArme (int ida, int idp){
        
        G_Personnage.GetPersonnage(idp).RecevoirArme(G_Armes.GetArme(ida));
    } //id de l'arme, id du personnage

	public static void Frapper (int idpAgresseur, int idpVictime) {
        G_Personnage.GetPersonnage(idpAgresseur).Frapper(G_Personnage.GetPersonnage(idpVictime));
    }

	public static void SupprimerPers (int idp){
        G_Personnage.SupprimerPers(idp);
    }
	//informations affichables
	public static IEnumerable<string> AfficherArmesDisponibles() {
        List<string> nomArmes = new List<string>();
        foreach (Arme a in G_Armes.ListerTtesArmes()) {
            nomArmes.Add(String.Format("{0,-2} | {1}", a.GetId(), a.GetNom()));
        }
        return nomArmes;
    } //toutes les armes cr��es
	public static string AfficherPersonnageDC(int idp) {
        return G_Personnage.GetPersonnage(idp).PresentationCourte();
    } 
	public static string AfficherPersonnageDD(int idp){
        return G_Personnage.GetPersonnage(idp).PresentationDetail();
    }
	public static IEnumerable<string> AfficherTsPersonnagesDC(){
        List<string> dc = new List<string>();
        foreach (Personnage p in G_Personnage.ListerTsPersonnages())
        {
            dc.Add(p.PresentationCourte());
        }
        return dc;
    } //description courte
	public static IEnumerable<string> AfficherTsPersonnagesDD(){
        List<string> dd = new List<string>();
        foreach (Personnage p in G_Personnage.ListerTsPersonnages())
        {
            dd.Add(p.PresentationDetail());
        }
        return dd;
    } //description detaill�e
	//pour les tests
	public static IEnumerable<Personnage> ListerTsPersonnages() {
        return G_Personnage.ListerTsPersonnages();
    } //tous les personnages cr��s
	public static Personnage GetPersonnage (int idp){
        return G_Personnage.GetPersonnage(idp);
    } // personnage d'identifiant idp
	public static IEnumerable<Arme> ListerTtesArmes() {
        return G_Armes.ListerTtesArmes();
    } // toutes les armes disponibles
	public static Arme GetArme(int ida){
        return G_Armes.GetArme(ida);
    } //arme d'identifiant idaa
	public static IEnumerable<Arme> GetArmes(int idp){
        return G_Personnage.GetPersonnage(idp).GetListeArmes();
    } //liste des armes du personnage d'identifiant idp
	
	}
}

