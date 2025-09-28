package com.app;

import com.app.*;
import com.app.Menu.*;
import io.github.nickacpt.jmenu.JMenu;
import io.github.nickacpt.jmenu.annotations.Option;
import java.util.Scanner;


public class PCMenu extends ClassMenu {

	public PCMenu(JMenu parent) {
		super(parent, PlayerCharacter.class);
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

		PlayerCharacter player = new PlayerCharacter(name, health);
		DBProvider.persist(player);

		this.run();
	}

	@Option(ordinal = 2, key = '3', description = "Удалить запись")
	public void delete() {
		PlayerCharacter player = inputEntity(PlayerCharacter.class, "Пункт: ");

		if (player != null) {
			if (player.getLevels().size() == 0) {
				DBProvider.remove(player);
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