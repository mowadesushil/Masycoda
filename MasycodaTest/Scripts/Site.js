function GetResponse() {
	$("#lblOutPut").text("");
	var nofOfBalls = $("#txtNoOfBalls").val();
	var nofOfOperations = $("#txtNoOfOperations").val();
	var sequence = $("#txtSequesnce").val();


	$.get("/Home/ChooseBall?noOfBalls=" + nofOfBalls + "&totalOperations=" + nofOfOperations + "&sequence=" + sequence, function (response) {

		$("#lblOutPut").text(response);

	});

}