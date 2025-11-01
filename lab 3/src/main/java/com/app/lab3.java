package com.app;

import com.app.*;
import com.app.Menu.*;
import java.util.List;
import java.util.ArrayList;








public class lab3 {
	public static void main (String args[]){

		DBProvider.init();

		new MainMenu().run();

		DBProvider.close();
	}
}