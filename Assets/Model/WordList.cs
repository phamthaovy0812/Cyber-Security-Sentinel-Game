[System.Serializable]
public class WordList
{

     public int level;
     public string[] listWords;
     public string[] wishedList;

     public WordList()
     {

     }
     public WordList(int level, string[] listWords, string[] wishedList)
     {
          this.level = level;
          this.listWords = listWords;
          this.wishedList = wishedList;
     }

}

