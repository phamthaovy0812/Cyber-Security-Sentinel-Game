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
    public User(string id, string email, string username, string password, string id_level, int experience)
    {
        this.id_user = id;
        this.email = email;
        this.username = username;
        this.password = password;
        this.id_level = id_level;
        this.experience = experience;
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
    public string correctAnswer;

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