using ManagementApp.Repo;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApp.Repo
{
    class PlacesRepo
    {
        internal static IList<Place> GetAllPlaces()
        {
            return RestCom<IList<Place>>.CommunicateGet(ApiStrings.PLACES);
        }
    }
}
