import java.util.*;
import java.io.*;

class StringMatching {

	String textInput;
	ArrayList<Character> arrayKarakterInputnya;

	public StringMatching(String dariMain) {
		textInput = dariMain;
		arrayKarakterInputnya = new ArrayList<Character>(dariMain.length());
	}

	public void algoritmaBoyerMoore(String patternInput) {
		ArrayList<Character> patternVec = new ArrayList<Character>(patternInput.length());
		patternVec = fromStringToVector(patternInput);

		int ip = 0;
		int it = patternVec.size();


	}

	public ArrayList<Character> fromStringToVector(String convert) {
		ArrayList<Character> vecOutput = new ArrayList<Character>(convert.length());
		for (int i = 0; i < convert.length(); i++) {
			vecOutput.add(i, convert.charAt(i));
		}
		return vecOutput;
	}

}