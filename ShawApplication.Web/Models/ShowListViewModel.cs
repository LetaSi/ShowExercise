using ShawApplication.Web.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;

namespace ShawApplication.Web.Models
{
    [Serializable]
    public class ShowListViewModel
    {
        public List<Show> shows { get; set; }
        public List<Alphabet> alphabets { get; set; }
        public string ShowsJson { get; set; }

        #region mapping and filling view model
        public static void PopulateViewModel(List<Show> dataSource, ShowListViewModel viewModel)
        {
            JavaScriptSerializer s = new JavaScriptSerializer();
            viewModel.shows = dataSource;
            if (viewModel.shows.Count > 0)
            {
                viewModel.ShowsJson = s.Serialize(dataSource);
            }
            viewModel.alphabets = GetAlphabets(dataSource);
        }

        private static List<Alphabet> GetAlphabets(List<Show> list)
        {
            List<Alphabet> lst = new List<Alphabet>();
            string[] alphabets = string.Format("A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z").Split(new char[] { ',' });
            var showFisrtLetterArray = list.Select(o => o.Name[0].ToString().ToUpper())
                .Distinct().ToList();
            for (int i = 0; i < alphabets.Length; i++)
            {
                Alphabet a = new Alphabet();
                a.Alpha = alphabets[i];
                if (showFisrtLetterArray.Contains(alphabets[i]))
                    a.HasShow = true;
                else
                    a.HasShow = false;
                lst.Add(a);
            }
            return lst;
        }
        #endregion
    }
}