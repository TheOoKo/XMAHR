namespace MMCWeb.Models
{
    public class ContactInfoModel
    {
        private string _Email;
        public string Name { get; set; }
        public string Email
        {
            get
            {
                if (this._Email == null)
                {
                    return "info@myanmarmedicalcouncil.org.mm";
                }
                return this._Email;
            }
            set
            {
                this._Email = value;
            }
        }
        public string Phone { get; set; }
        public string Message { get; set; }

    }
}