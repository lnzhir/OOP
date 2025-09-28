package com.app;

import com.app.*;
import com.app.Menu.*;
import io.github.nickacpt.jmenu.JMenu;
import io.github.nickacpt.jmenu.annotations.Option;
import java.util.Scanner;


public class NPCMenu extends ClassMenu {

	public NPCMenu(JMenu parent) {
		super(parent, NonPlayerCharacter.class);
	}

	@Option(ordinal = 0, key = '1', description = "Весь список")
	public void list() {
		super.list();
	}

	@Option(ordinal = 1, key = '2', description = "Добавить запись")
	public void add() {
		Scanner in = new Scanner(System.in);
		System.out.print("Name: ");
		String name = in.nextLine();
		System.out.print("Health: ");
		int health = in.nextInt();
		System.out.print("Role: ");
		String role = in.next();
		System.out.print("Attitude: ");
		int attitude = in.nextInt();

		NonPlayerCharacter npc = new NonPlayerCharacter(name, health, role, attitude);
		DBProvider.persist(npc);

		this.run();
	}

	@Option(ordinal = 2, key = '3', description = "Удалить запись")
	public void delete() {
		NonPlayerCharacter npc = inputEntity(NonPlayerCharacter.class, "Пункт: ");

		if (npc != null) {
			if (npc.getLevels().size() == 0) {
				DBProvider.remove(npc);
			} else {
				System.out.println("Не удалено. Присутствует в одном (нескольких) из уровней");
			}
		}
		this.run();
	}

	@Option(ordinal = 3, key = '4', description = "Назад")
	public void back() {
		super.back();
	}
}