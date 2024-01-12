[System.Serializable]
public class ArrayAnswer
{
	public string answer;
	public bool isCorrect;
	public ArrayAnswer(string answer, bool isCorrect)
	{
		this.answer = answer;
		this.isCorrect = isCorrect;

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
