using RestApi.Model;

namespace RestApi.Dto  
{
    public class AboutMeDto : BaseModel
    {
        public AboutMeDto() {
            this.Hash = this.GetHashCode();
        }

        public int Test {get; set;}
    }
}