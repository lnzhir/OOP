package com.app.Menu;

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

		Game game = GameMenu.inputGame();
		if (game != null) {
			PlayerCharacter player = new PlayerCharacter(name, health, game);
			game.getPCs().add(player);
			DBProvider.persist(player);
		}

		this.run();
	}

	@Option(ordinal = 2, key = '3', description = "Изменить запись")
	public void update() {
		PlayerCharacter player = inputEntity(PlayerCharacter.class, "Пункт: ");

		if (player != null) {
			Scanner in = new Scanner(System.in);
			System.out.print("Name: ");
			String name = in.nextLine();
			System.out.print("Health: ");
			int health = in.nextInt();
			System.out.print("Level: ");
			int level = in.nextInt();
			System.out.print("Experience: ");
			int experience = in.nextInt();

			DBProvider.transact(() -> {
				player.setName(name);
				player.setHealth(health);
				player.setLevel(level);
				player.setExperience(experience);
			});
		}

		this.run();
	}


	@Option(ordinal = 3, key = '4', description = "Удалить запись")
	public void delete() {
		super.delete();
	}

	@Option(ordinal = 4, key = '5', description = "Назад")
	public void back() {
		super.back();
	}
}