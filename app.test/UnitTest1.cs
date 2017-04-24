using System;
using System.Collections.Generic;
using Xunit;

using app;

namespace app.test
{
    public class UnitTest1
    {
        [Fact(Skip="123")]
        public async void Test_MemberRepository_Basic_GetDataAsync()
        {
            var key = "-KiUSqrMni578d--QjYz";

            var expected = "123";
            await MemberRepository.Instance.GetDataAsync(key);

            //Assert.True(string.IsNullOrEmpty(actual));
            //Assert.Equal(expected,actual);
        }

       [Fact]
        public async void Test_MemberRepository_SetDataAsync()
        {
            var key = DateTime.Now.ToString("yyymmsshhmmss");
            var value = new Random(DateTime.Now.Millisecond).Next().ToString();
            var memberData = new KeyValuePair<string,string>(key, value);

            var expected = true;
            await MemberRepository.Instance.SetDataAsync("Member",memberData);

            //Assert.Equal(expected,actual);
        }
    }
}
