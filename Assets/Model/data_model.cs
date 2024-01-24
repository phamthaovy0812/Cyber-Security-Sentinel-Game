[System.Serializable]
public class ArrayAnswer
{
	public string answer;
	public bool isCorrect;
	public int question; // 1 laf dau hieu nhan biet ; 2 cach phong trannh
	public ArrayAnswer(string answer, bool isCorrect, int question = 1)
	{
		this.answer = answer;
		this.isCorrect = isCorrect;
		this.question = question;

	}

}
[System.Serializable]
public class ListArrayAnswer
{
	public int level;
	public ArrayAnswer[] arrayAnswers;

	public ListArrayAnswer(int level, ArrayAnswer[] arrayAnswers)
	{
		this.level = level;
		this.arrayAnswers = arrayAnswers;
	}
}
