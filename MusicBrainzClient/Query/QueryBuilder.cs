using System;
using System.Text;

namespace MusicBrainzClient.Query 
{
    public class QueryBuilder
    {
        private readonly StringBuilder _StringBuilder = new StringBuilder();
        private bool _First = true;

        public QueryBuilder(string search=null) 
        {
            if (search == null)
                return;

            _First = false;
            _StringBuilder.Append(search);
        }

        public QueryBuilder AndStrict(string attribute, object value) 
        {
            return Append(" AND ", attribute, $"\"{value}\"" );
        }

        public QueryBuilder And(string attribute, object value) 
        {
            return Append(" AND ", attribute, $"({value.ToString().ToLower()})");
        }

        private QueryBuilder Append(string Operator, string attribute, string value) 
        {
            OnNext(() => _StringBuilder.Append(Operator));
            Add(attribute, value);
            return this;
        }

        private void Add(string attribute, object value) 
        {
            _StringBuilder.Append($"{attribute}:{value}");
        }

        private void OnNext(Action doOnNext) 
        {
            if (!_First) 
                doOnNext();

            _First = false;
        }

        public override string ToString() 
        {
            return _StringBuilder.ToString();
        }
    }
}
