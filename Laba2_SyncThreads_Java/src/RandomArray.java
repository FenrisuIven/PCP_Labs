import java.util.Random;

public class RandomArray {
	public final int[] array;
	
	public RandomArray (int amountOfElements, int maxValue) {
		this.array = new int[amountOfElements];
		
		initArray(amountOfElements, maxValue);
	}
	
	void initArray(int amountOfElements, int maxValue) {
		Random rnd = new Random();
		int targetRandomElem = amountOfElements / 2;
		
		for(int i = 0; i < amountOfElements; i++){
			array[i] = rnd.nextInt(maxValue) + 1;
			if (i == targetRandomElem) array[i] *= -1;
		}
	}
	
	public ArrayElement findMinElemInSection (int sectionStart, int sectionEnd){
		int min = Integer.MAX_VALUE;
		int idx = -1;
		for(int i = sectionStart; i <= sectionEnd; i++){
			if(array[i] < min) {
				min = array[i];
				idx = i;
			}
		}
		return new ArrayElement(min, idx);
	}
}

