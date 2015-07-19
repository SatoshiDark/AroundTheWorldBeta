#pragma strict

var score: int = 0;


//=======================================================================================================
// Several simple example functions, that can be called to change parameters
function InScore (amount:int) {
  score += amount;
}

//---------------------------------------------------------------------------------------------
// Display current values
function OnGUI () {
    GUI.Label (Rect (65, 20, 100, 20),   "SCORE:  " + score.ToString());
}
