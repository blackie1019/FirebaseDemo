using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Firebase.Database;

using app.Model;
using Newtonsoft.Json;

namespace app
{
    public class MemberRepository
    {
        private static readonly Lazy<MemberRepository> lazy = new Lazy<MemberRepository>(() => new MemberRepository());
        public static MemberRepository Instance { get { return lazy.Value; } }

        private FirebaseClient Firebase { get; }

        private MemberRepository()
        {
            var auth = "A3tOMg03YuZNLIh4iIZUGtzwi9FlBt867dn3Sv3p";
            var baseUrl = "https://dotnetcoredemo-657bd.firebaseio.com";
            var option = new FirebaseOptions()
            {
                AuthTokenAsyncFactory = () => Task.FromResult(auth)
            };

            this.Firebase = new FirebaseClient(baseUrl, option);
        }

        public async Task GetDataAsync(string key)
        {
            var data = await this.Firebase
                .Child(key)
                .OnceAsync<string>();

            foreach (var item in data){
                Console.WriteLine(string.Format("Get Async Data from key({0}) = {1}:{2}",
                    key,
                    item.Key,
                    item.Object));
            }

        }

        public async Task SetDataAsync(string key, KeyValuePair<string, string> data)
        {
            var result = await this.Firebase
                .Child(key)
                .PostAsync(JsonConvert.SerializeObject(new Member(){ 
                    Name = data.Key,
                    Tag = data.Value
                    }));

            Console.WriteLine(string.Format("Post Async Data to key({0}) = {1}", result.Key, result.Object));
        }
    }
}
