using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasycodaTest.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			 


			return View();
		}


		[HttpGet]
		public JsonResult ChooseBall(int noOfBalls, int totalOperations, string sequence)
		{		    

			double whiteBallPosibility = 0;

			List<int> whiteBallPositions = new List<int>();
			List<int> blackBallPositions = new List<int>();
			if (!string.IsNullOrEmpty(sequence))
			{
				for (int i = 0; i < sequence.Length; i++)
				{
					if (sequence[i] == 'B' || sequence[i] == 'b')
					{
						blackBallPositions.Add(i);
					}

					if (sequence[i] == 'W' || sequence[i] == 'w')
					{
						whiteBallPositions.Add(i);
					}
				}
			}


			for (int i = 0; i < totalOperations; i++)
			{
				double tempWhiteBallPosibility = 0;
				int leftWhiteBallIndex = -1;
				int rightWhiteBallIndex = -1;

				if (whiteBallPositions.Count > 0){
					  leftWhiteBallIndex = whiteBallPositions[0];
					  rightWhiteBallIndex = whiteBallPositions[whiteBallPositions.Count - 1];
				}

				int leftTotalBlackBalls = 0;
				int rightTotalBlackBall = 0;

				if (leftWhiteBallIndex == 0)
				{
					whiteBallPosibility = whiteBallPosibility + 1;
					whiteBallPositions.Remove(leftWhiteBallIndex);
					sequence = sequence.Remove(0, 1);
					//allBallPositions.Remove(leftTotalBlackBalls);

				}
				else
				{
					if (rightWhiteBallIndex == sequence.Length - 1)
					{
						whiteBallPosibility = whiteBallPosibility + 1;
						whiteBallPositions.Remove(rightWhiteBallIndex);
						sequence = sequence.Remove(sequence.Length - 1, 1);
						//allBallPositions.Remove(rightWhiteBallIndex);
					}
					else
					{


						if (leftWhiteBallIndex > 0)
						{
							if (blackBallPositions != null && blackBallPositions.Count > 0)
							{
								for (int l = blackBallPositions[0]; l < leftWhiteBallIndex; l++)
								{
									leftTotalBlackBalls = leftTotalBlackBalls + 1;
								}


								for (int r = blackBallPositions[blackBallPositions.Count - 1]; r > rightWhiteBallIndex; r--)
								{
									rightTotalBlackBall = rightTotalBlackBall + 1;
								}
							}


							if (leftTotalBlackBalls < rightTotalBlackBall)
							{
								if (blackBallPositions.Count > 0)
								{
									for (int j = 0; j < leftTotalBlackBalls; j++)
									{
										blackBallPositions.Remove(j);

									}
								}

								if (whiteBallPositions.Count > 0)
								{

									whiteBallPositions.Remove(leftWhiteBallIndex);
								}

								if (leftTotalBlackBalls > 0)
								{
									for (int k = 1; k <= rightTotalBlackBall; k++)
									{
										tempWhiteBallPosibility = tempWhiteBallPosibility + 0.5;
									}
								}
								else
								{
									tempWhiteBallPosibility = tempWhiteBallPosibility + 1;
								}
							}
							else
							{
								if (blackBallPositions != null && blackBallPositions.Count > 0)
								{
									for (int r = blackBallPositions[blackBallPositions.Count - 1]; r > rightWhiteBallIndex; r--)
									{
										blackBallPositions.Remove(r);
									}
								}

								if (whiteBallPositions.Count > 0)
								{
									whiteBallPositions.Remove(rightWhiteBallIndex);
								}

								if (rightTotalBlackBall > 0)
								{
									for (int k = 1; k <= rightTotalBlackBall; k++)
									{
										tempWhiteBallPosibility = tempWhiteBallPosibility + 0.5;
									}
								}
								else
								{
									tempWhiteBallPosibility = tempWhiteBallPosibility + 1;
								}
							}

						}
					}
				}


				whiteBallPosibility = whiteBallPosibility + tempWhiteBallPosibility;

			}




			return Json(whiteBallPosibility, JsonRequestBehavior.AllowGet);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}