using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace CreativaSL.Web.Escuela.Models
{
    public class CustomIdentity : IIdentity
    {
        private FormsAuthenticationTicket _ticket;

        private List<string> _ListaPermiso;
        public CustomIdentity(FormsAuthenticationTicket ticket)
        {
            _ticket = ticket;
            JObject resut = (JObject)JsonConvert.DeserializeObject(_ticket.UserData);
            JsonSerializer serializer = new JsonSerializer();
            AdministrativoPermisoJson item = (AdministrativoPermisoJson)serializer.Deserialize(new JTokenReader(resut), typeof(AdministrativoPermisoJson));
            _ListaPermiso = item.NombreURl;
        }


        public string AuthenticationType
        {
            get
            {
                return "Custom";
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return true;
            }
        }

        public string Name
        {
            get
            {
                return _ticket.Name;
            }
        }

        public FormsAuthenticationTicket Ticket
        {
            get { return _ticket; }
        }

        public List<string> NombreUrl
        {
            get
            {
                return _ListaPermiso;
            }
        }
    }
}