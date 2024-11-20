using MediaTekDocuments.manager;
using MediaTekDocuments.model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace MediaTekDocuments.dal
{
    class FrmgestionAccess
    {
        private static readonly string uriApi = "http://localhost/rest_mediatekdocuments/";
        private static FrmgestionAccess instance = null;
        private readonly ApiRest api = null;
        private const string GET = "GET";
        private const string POST = "POST";
        private const string PUT = "PUT";
        private const string DELETE = "DELETE";
        private FrmgestionAccess()
        {
            String authenticationString;
            try
            {
                authenticationString = "admin:adminpwd";
                api = ApiRest.GetInstance(uriApi, authenticationString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }

        public static FrmgestionAccess GetInstance()
        {
            if (instance == null)
            {
                instance = new FrmgestionAccess();
            }
            return instance;
        }

        /// <summary>
        /// Retourne toutes les commandes à partir de la bdd
        /// </summary>
        /// <returns>Liste d'objets Commande</returns>
        public List<Commande> GetAllCommandes()
        {
            List<Commande> lesCommandes = TraitementRecup<Commande>(GET, "commande", null);
            return lesCommandes;
        }

        /// <summary>
        /// Retourne toutes les commandes de documents à partir de la bdd
        /// </summary>
        /// <returns>Liste d'objets CommandeDocument</returns>
        public List<CommandeDocument> GetAllCommandedocuments()
        {
            List<CommandeDocument> lesCommandesDocuments = TraitementRecup<CommandeDocument>(GET, "commandedocument", null);
            return lesCommandesDocuments;
        }

        /// <summary>
        /// Retourne toutes les étapes de suivi des commandes à partir de la bdd
        /// </summary>
        /// <returns>Liste d'objets Suivi</returns>
        public List<Suivi> GetAllSuivi()
        {
            List<Suivi> lesSuivi = TraitementRecup<Suivi>(GET, "suivi", null);
            return lesSuivi;
        }

        /// <summary>
        /// Retourne toutes les livres à partir de de la bdd
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            List<Livre> lesLivres = TraitementRecup<Livre>(GET, "livre", null);
            return lesLivres;
        }

        /// <summary>
        /// Retourne toutes les commandes de documents avec leurs détails de suivi à partir de la bdd
        /// </summary>
        /// <returns>Liste d'objets CommandeDocument</returns>
        public List<DetailsCommande> GetDetailCommande(string idLivreDvd)
        {
            String jsonIdLivreDvd = convertToJson("idLivreDvd", idLivreDvd);
            List<DetailsCommande> lesDetailCommandes = TraitementRecup<DetailsCommande>(GET, "detailcommande/" + jsonIdLivreDvd, null);
            return lesDetailCommandes;
        }

        /// <summary>
        /// Ecriture d'un détail de commande en base de données
        /// </summary>
        /// <param name="detailsCommande">Détail de commande à insérer</param>
        /// <returns>true si l'insertion a pu se faire (retour != null)</returns>
        public bool CreerDetailCommande(DetailsCommande detailsCommande)
        {
            string jsonDetailCommande = JsonConvert.SerializeObject(detailsCommande, new CustomDateTimeConverter());
            Console.WriteLine(uriApi + "detailcommande?champs=" + jsonDetailCommande) ;
            try
            {
                List<DetailsCommande> liste = TraitementRecup<DetailsCommande>(POST, "detailcommande", "champs=" + jsonDetailCommande);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool ModifierDetailCommande(DetailsCommande detailsCommande)
        {
            string jsonDetailCommande = JsonConvert.SerializeObject(detailsCommande, new CustomDateTimeConverter());
            Console.WriteLine(uriApi + "detailcommande?champs=" + jsonDetailCommande);
            try
            {
                List<DetailsCommande> liste = TraitementRecup<DetailsCommande>(PUT, "detailcommande", "champs=" + jsonDetailCommande);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool SupprimerDetailCommande(DetailsCommande detailsCommande)
        {
            string jsonDetailCommande = JsonConvert.SerializeObject(detailsCommande, new CustomDateTimeConverter());
            Console.WriteLine(uriApi + "detailcommande/" + jsonDetailCommande);
            try
            {
                List<DetailsCommande> liste = TraitementRecup<DetailsCommande>(DELETE, "detailcommande/" + jsonDetailCommande, null);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public List<DetailsAbonnement> GetDetailAbonnement(string idRevue)
        {
            String jsonIdRevue = convertToJson("idRevue", idRevue);
            Console.WriteLine(uriApi + "detailabonnement/" + jsonIdRevue);
            List<DetailsAbonnement> lesDetailAbonnements = TraitementRecup<DetailsAbonnement>(GET, "detailabonnement/" + jsonIdRevue, null);
            return lesDetailAbonnements;
        }

        public bool CreerDetailAbonnement(DetailsAbonnement detailsAbonnement)
        {
            string jsonDetailAbonnement = JsonConvert.SerializeObject(detailsAbonnement, new CustomDateTimeConverter());
            Console.WriteLine(uriApi + "detailabonnement?champs=" + jsonDetailAbonnement);
            try
            {
                List<DetailsAbonnement> liste = TraitementRecup<DetailsAbonnement>(POST, "detailabonnement", "champs=" + jsonDetailAbonnement);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool SupprimerDetailAbonnement(DetailsAbonnement detailsAbonnement)
        {
            string jsonDetailAbonnement = JsonConvert.SerializeObject(detailsAbonnement, new CustomDateTimeConverter());
            Console.WriteLine(uriApi + "detailabonnement/" + jsonDetailAbonnement);
            try
            {
                List<DetailsAbonnement> liste = TraitementRecup<DetailsAbonnement>(DELETE, "detailabonnement/" + jsonDetailAbonnement, null);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }



        private List<T> TraitementRecup<T>(String methode, String message, String parametres)
        {
            List<T> liste = new List<T>();
            try
            {
                JObject retour = api.RecupDistant(methode, message, parametres);
                String code = (String)retour["code"];
                if (code.Equals("200"))
                {
                    if (methode.Equals(GET))
                    {
                        String resultString = JsonConvert.SerializeObject(retour["result"]);
                        liste = JsonConvert.DeserializeObject<List<T>>(resultString);
                    }
                }
                else
                {
                    Console.WriteLine("Erreur : " + code + " - " + (String)retour["message"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur d'accès à l'API : " + e.Message);
            }
            return liste;
        }

        private String convertToJson(String key, String value)
        {
            return $"{{\"{key}\": \"{value}\"}}";
        }

        // <summary>
        /// Convertit en json un couple nom/valeur
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="valeur"></param>
        /// <returns>couple au format json</returns>
        private String convertToJson(Object nom, Object valeur)
        {
            Dictionary<Object, Object> dictionary = new Dictionary<Object, Object>();
            dictionary.Add(nom, valeur);
            return JsonConvert.SerializeObject(dictionary);
        }

        /// <summary>
        /// Modification du convertisseur Json pour gérer le format de date
        /// </summary>
        private sealed class CustomDateTimeConverter : IsoDateTimeConverter
        {
            public CustomDateTimeConverter()
            {
                base.DateTimeFormat = "yyyy-MM-dd";
            }
        }

        /// <summary>
        /// Modification du convertisseur Json pour prendre en compte les booléens
        /// classe trouvée sur le site :
        /// https://www.thecodebuzz.com/newtonsoft-jsonreaderexception-could-not-convert-string-to-boolean/
        /// </summary>
        private sealed class CustomBooleanJsonConverter : JsonConverter<bool>
        {
            public override bool ReadJson(JsonReader reader, Type objectType, bool existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                return Convert.ToBoolean(reader.ValueType == typeof(string) ? Convert.ToByte(reader.Value) : reader.Value);
            }

            public override void WriteJson(JsonWriter writer, bool value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
        }
    }
}
