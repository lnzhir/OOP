package com.app;

import com.app.Character;
import java.util.Collection;
import java.util.List;
import java.util.ArrayList;
import jakarta.persistence.*;
import lombok.*;


@Getter
@Setter
@NoArgsConstructor(access = AccessLevel.PRIVATE)
@Entity
@Table(name = "\"PlayerCharacters\"")
public class PlayerCharacter extends Character {
	@Column(name = "level")
	private int level = 1;

	@Column(name = "experience")
	private int experience = 0;

	private static int EXP_COEFF = 1000;
	private static int curTime = 0;


	public PlayerCharacter(String name, int health, Game game) {
		super(name, health, game);
		//this.game = game;
	}

	public PlayerCharacter(String name, int health, int level, int experience, Game game) {
		super(name, health, game);
		this.level = level;
		this.experience = experience;
		//this.game = game;
	}

	public void levelUp() {
		level += 1;
		System.out.printf("%s leveled up to %d\n", name, level);
	}

	public void addExperience(int value) {
		experience += value;

		int maxExp = EXP_COEFF*level;
		int n = 0;
		while (experience > maxExp) {
			n++;
			level++;
			experience -= maxExp;
			maxExp = EXP_COEFF*level;
		}
		if (n > 0) {
			System.out.printf("%s leveled up to %d\n", name, level);
		}
	}

	public void sleep(int hours) {
		curTime = (curTime+hours)%24;
		System.out.printf("%s sleps %d hours\nCurrent time: %dh", name, hours, curTime);
	}

	public void death() {
		System.out.printf("%s died\nGame over", name);
	}

	public String toString() {
		return String.format("Name: '%s' Health: %d Level: %d Experience: %d Game: '%s'", name, health, level, experience, game.getName());
	}
}