package com.app.Menu;

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

		Game game = GameMenu.inputGame();
		if (game != null) {
			NonPlayerCharacter npc = new NonPlayerCharacter(name, health, role, attitude, game);
			game.getNPCs().add(npc);
			DBProvider.persist(npc);
		}
		

		this.run();
	}

	@Option(ordinal = 2, key = '3', description = "Изменить запись")
	public void update() {
		NonPlayerCharacter npc = inputEntity(NonPlayerCharacter.class, "Пункт: ");

		if (npc != null) {
			Scanner in = new Scanner(System.in);
			System.out.print("Name: ");
			String name = in.nextLine();
			System.out.print("Health: ");
			int health = in.nextInt();
			System.out.print("Role: ");
			String role = in.next();
			System.out.print("Attitude: ");
			int attitude = in.nextInt();

			DBProvider.transact(() -> {
				npc.setName(name);
				npc.setHealth(health);
				npc.setAttitude(attitude);
				npc.setRole(role);
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