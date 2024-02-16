
using System.Collections.Generic;
using UnityEngine;

public class DialogString : MonoBehaviour
{
	// NPC police
	public List<List<string>> docBeginStartingGame = new List<List<string>>{
		new List<string>{"Xin chào! Chào mừng bạn đến với Cybersecurity Sentinel. Hãy tận hưởng những trải nghiệm tuyệt vời tại đây nhé!",
		"Đầu tiên, hãy đến Sở cảnh sát để nhận nhiệm vụ đầu tiên!"}
	};
	public List<List<string>> docBeginStartingSeePoliceDegree1 = new List<List<string>>{
		new List<string> {
		 "Trong thời buổi mà lừa đảo qua mạng ngày càng tràn lan và tinh vi, nhiều người dân đã vướng phải những phi vụ lừa đảo, dẫn đến mất mát về vật chất lẫn tinh thần.",
		 "Sở cảnh sát Thành phố A chúng tôi đang bị thiếu hụt nhân lực trầm trọng.",
		  "Chúng tôi đã nhận được rất nhiều hồ sơ ứng tuyển, và chúng tôi nhận thấy hồ sơ của bạn rất đặc biệt nên đã liên hệ với bạn để cùng bàn bạc về việc này. Chúng ta bắt đầu nhé?"
		 },
		 new List<string> {
		 "Vâng thưa quản lý.",
		 },
		 new List<string> {
		 "Công việc này là một công việc khó khăn, đòi hỏi về những kiến thức chuyên môn liên quan phải vững chắc.",
		 "Đây là một hành trình dài và không dễ dàng, bạn chắc chắn muốn tham gia cùng chúng tôi chứ ?",

		 },
		 new List<string> {
		 "Đúng vậy, tôi rất yêu thích về an toàn thông tin và muốn góp sức mình để giúp đỡ người dân, phòng ngừa các vụ lừa đảo qua mạng ngày càng tràn lan trong xã hội. ",
		 "Vậy nên tôi ở đây để ứng tuyển vào vị trí thực tập sinh."
		 },
		 new List<string> {
		 "Bạn hãy đến cấp 1 để hoàn thành nhiệm vụ đầu tiên.",
		 "Chúc bạn may mắn!"
		 },


	};
	public List<List<string>> docBeginStartingSeePoliceDegree2 = new List<List<string>>{
		new List<string> {
		 "Chúc mừng bạn đã hoàn thành cấp 1. Hãy đến cấp 2!",
		},
		 new List<string> {
		 "Vâng thưa quản lý.",
		 },

	};
	public List<List<string>> docBeginStartingSeePoliceDegree3 = new List<List<string>>{
		new List<string> {
		 "Chúc mừng bạn đã hoàn thành cấp 2. Hãy đến cấp 3!",
		},
		 new List<string> {
		 "Vâng thưa quản lý.",
		 },
	};
	public List<List<string>> docBeginStartingSeePoliceDegree4 = new List<List<string>>{
		new List<string> {
		 "Chúc mừng bạn đã hoàn thành cấp 3. Hãy đến cấp 4!",
		},
		 new List<string> {
		 "Vâng thưa quản lý.",
		 },

	};

	public List<List<string>> docNoCompleteDegree1 = new List<List<string>>{
		new List<string> {"Chào bạn, chúng tôi nhận thấy bạn chưa hoàn thành tiến độ của cấp bậc 1, hãy quay lại địa điểm cấp bậc 1 và tiếp tục làm nhiệm vụ. ",
		"Chúc bạn may mắn."},

	};
	public List<List<string>> docNoCompleteDegree2 = new List<List<string>>{
		new List<string> {"Chào bạn, chúng tôi nhận thấy bạn chưa hoàn thành tiến độ của cấp bậc 2, hãy quay lại địa điểm cấp bậc 2 và tiếp tục làm nhiệm vụ. ",
		"Chúc bạn may mắn."},

	};
	public List<List<string>> docNoCompleteDegree3 = new List<List<string>>{
		new List<string> {"Chào bạn, chúng tôi nhận thấy bạn chưa hoàn thành tiến độ của cấp bậc 3, hãy quay lại địa điểm cấp bậc 3 và tiếp tục làm nhiệm vụ. ",
		"Chúc bạn may mắn."},

	};
	public List<List<string>> docNoCompleteDegree4 = new List<List<string>>{
		new List<string> {"Chào bạn, chúng tôi nhận thấy bạn chưa hoàn thành tiến độ của cấp bậc 4, hãy quay lại địa điểm cấp bậc 4 và tiếp tục làm nhiệm vụ. ",
		"Chúc bạn may mắn."},

	};

	// NPC degree 1
	public List<List<string>> docBeginStartingSeeNPCDegree1 = new List<List<string>>{
		new List<string> {"Chào mừng bạn đến trò chơi cấp 1."},
		new List<string> {" Ở cấp chơi này bạn sẽ di chuyển nhân vật và đặt bom để tiêu diệt tàu vũ trụ, quái vật nguy hiểm. Cấp bậc sẽ bao gồm 6 level khác nhau. Ở mỗi level bạn cần phải hoàn thành trong thời gian quy định để nhận điểm kinh nghiệm thăng cấp."},
		new List<string> {"Chúc bạn may mắn."},
	};
	public List<List<string>> docAfterSeeNPCDegree1 = new List<List<string>>{
		new List<string> {"Tiếp tục trò chơi cấp 1"},
	};
	public List<List<string>> docAfterCompleteDegree1 = new List<List<string>>{
		new List<string> {"Bạn đã hoàn thành cấp 1. bạn có muốn tiếp tục tham gia lại lần nữa không? (Điểm kinh nghiệm sẽ được cộng theo mức độ chơi tốt nhất của bạn)."},
	};
	// NPC degree 2
	public List<List<string>> docBeginStartingSeeNPCDegree2 = new List<List<string>>{
		new List<string> {"Chào mừng bạn đến trò chơi cấp 2!"},
	};
	public List<List<string>> docAfterSeeNPCDegree2 = new List<List<string>>{
		new List<string> {"Tiếp tục trò chơi cấp 2."},
	};
	public List<List<string>> docAfterCompleteDegree2 = new List<List<string>>{
		new List<string> {"Bạn đã hoàn thành cấp 2. Bạn có muốn tiếp tục trò chơi cấp 2 nữa không?"},
	};

	// degree 3
	public List<List<string>> docBeginStartingSeeNPCDegree3 = new List<List<string>>{
		new List<string> {"Chào mừng bạn đến trò chơi cấp 3."},
		new List<string> {"Trong bối cảnh trộm cướp hoành hành. Là một cảnh sát dự bị bạn được giao nhiệm vụ truy đổi băng cướp trong thị trấn. Bạn sẽ phải điều khiển xe cảnh sát để truy đuổi băng cướp. Trong quá trình truy đuổi bạn cần trả lời các câu hỏi trên đường đi để loại bỏ đá trên đường cản trở bạn di chuyển.Cấp bậc sẽ bao gồm 4 level khác nhau. Ở mỗi level bạn cần phải hoàn thành trong thời gian quy định để nhận điểm kinh nghiệm thăng cấp."},
		new List<string> {"Chúc bạn may mắn!"},

	};
	public List<List<string>> docAfterSeeNPCDegree3 = new List<List<string>>{
		new List<string> {"Tiếp tục trò chơi cấp 3."},
	};
	public List<List<string>> docAfterCompleteDegree3 = new List<List<string>>{
		new List<string> {"Bạn đã hoàn thành cấp 3. Bạn có muốn Tiếp tục lại trò chơi cấp 3 nữa không?"},
	};
	// degree 3
	public List<List<string>> docBeginStartingSeeNPCDegree4 = new List<List<string>>{
		new List<string> {"Chào mừng bạn đến trò chơi cấp 4."},
	};
	public List<List<string>> docAfterSeeNPCDegree4 = new List<List<string>>{
		new List<string> {"Tiếp tục trò chơi cấp 4."},
	};
	public List<List<string>> docAfterCompleteDegree4 = new List<List<string>>{
		new List<string> {"Bạn đã hoàn thành cấp 4. Bạn có muốn Tiếp tục trò chơi cấp 4 nữa không?"},
	};
	void Start()
	{

	}



}