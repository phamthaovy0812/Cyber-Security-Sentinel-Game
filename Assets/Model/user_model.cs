[System.Serializable]
public class User
{
    public string email { get; set; }
    public string id_user { get; set; }
    public string password { get; set; }
    public string username { get; set; }
    public int experience { get; set; }
    public int id_level { get; set; }
    public bool isOpenDegree1 { get; set; }
    public bool isOpenDegree2 { get; set; }
    public bool isOpenDegree3 { get; set; }
    public bool isOpenDegree4 { get; set; }
    public bool isOpenStartGame { get; set; }

    public User()
    {
        this.id_user = "0";
        this.email = "";
        this.username = "username";
        this.password = "password";
        this.id_level = 0;
        this.experience = 0;
        this.isOpenDegree1 = false;
        this.isOpenDegree2 = false;
        this.isOpenDegree3 = false;
        this.isOpenDegree4 = false;
        this.isOpenStartGame = false;
    }
    public User(string id, string email, string username, string password, int id_level, int experience, bool isOpenDegree1 = false, bool isOpenDegree2 = false, bool isOpenDegree3 = false, bool isOpenDegree4 = false, bool isOpenStartGame = false)
    {
        this.id_user = id;
        this.email = email;
        this.username = username;
        this.password = password;
        this.id_level = id_level;
        this.experience = experience;
        this.isOpenDegree1 = isOpenDegree1;
        this.isOpenDegree2 = isOpenDegree2;
        this.isOpenDegree3 = isOpenDegree3;
        this.isOpenDegree4 = isOpenDegree4;
        this.isOpenStartGame = isOpenStartGame;
    }

}

public class Degree
{

    public string id;
    public string nameLevel;
    public Topic[] topics;
}
[System.Serializable]
public class Question
{
    public string id_question;
    public string question;
    public string answerA;
    public string answerB;
    public string answerC;
    public string answerD;
    public string correctAnswer; // a, b, c, d

    public Question()
    {

    }
    public Question(string id, string question, string answerA, string answerB, string answerC, string answerD, string correctAnswer)
    {

        this.id_question = id;
        this.question = question;
        this.answerA = answerA;
        this.answerB = answerB;
        this.answerC = answerC;
        this.answerD = answerD;
        this.correctAnswer = correctAnswer;

    }

}
[System.Serializable]

public class Topic
{
    public string id_topic;
    public string name_topic;
    public Question[] listQuestions;

    public Topic()
    {

    }
}