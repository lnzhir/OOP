package com.app.Menu;

import com.app.DBProvider;
import com.app.Menu.*;
import io.github.nickacpt.jmenu.JMenu;
import java.util.List;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;



public class ClassMenu<T> extends JMenu {
	private Class<T> entityClass;
	private JMenu parent;

	public ClassMenu(JMenu parent, Class<T> entityClass) {
		this.parent = parent;
		this.entityClass = entityClass;
	}

	public static <T> List<T> printList(List<T> entities) {
		for (int i = 0; i < entities.size(); i++) {
			System.out.printf("%d) %s\n", i, entities.get(i).toString());
		}
		return entities;
	}

	public static <T> List<T> printList(Class<T> entityClass) {
		return printList(DBProvider.getAll(entityClass));
	}

	public static <T> T inputEntity(List<T> entities, String msg) {
		Scanner in = new Scanner(System.in);
		System.out.print(msg);
		int index = in.nextInt();
		
		if (index >= 0 && index < entities.size()) {
			return entities.get(index);
		}
		else
			System.out.println("Такого нету");
		return null;
	}

	public static <T> T inputEntity(Class<T> entityClass, String msg) {
		List<T> entities = printList(entityClass);

		return inputEntity(entities, msg);
	}

	public void list() {
		printList(entityClass);
		this.run();
	}

	public void delete() {
		T entity = inputEntity(entityClass, "Пункт: ");

		if (entity != null) {
			DBProvider.remove(entity);
		}

		this.run();
	}

	public void back() {
		parent.run();
	}
}