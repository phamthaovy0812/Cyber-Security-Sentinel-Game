  [System.Serializable]
public class User
{
    public string email { get; set; }
    public string id_user { get; set; }
    public string password { get; set; }
    public string username { get; set; }
    public int experience { get; set; }
    public string id_level { get; set; }


    public User()
    {
        id_user = "0";
        email = username = password = id_level = "";
        experience = 0;
    }
    public User(string id, string email, string username, string password, string id_level, int experience){
        this.id_user = id;
        this.email = email;
        this.username = username;
        this.password = password;
        this.id_level = id_level;
        this.experience = experience;
    }
    
}