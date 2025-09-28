package com.app;

import com.app.Character;
import com.app.Level;
import java.util.Collection;
import java.util.List;
import java.util.ArrayList;
import jakarta.persistence.*;
import lombok.*;


@Getter
@NoArgsConstructor(access = AccessLevel.PUBLIC)
@Entity
@Table(name = "\"PlayerCharacters\"")
public class PlayerCharacter extends Character {
	@Column(name = "level")
	private int level = 1;

	@Column(name = "experience")
	private int experience = 0;

	@OneToMany(mappedBy = "playerCharacter", fetch = FetchType.EAGER)
	private List<Level> levels = new ArrayList<Level>();

	private static int EXP_COEFF = 1000;
	private static int curTime = 0;


	public PlayerCharacter(String name, int health) {
		super(name, health);
	}

	public PlayerCharacter(String name, int health, int level, int experience) {
		super(name, health);
		this.level = level;
		this.experience = experience;
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
		return String.format("Name: '%s' Health: %d Level: %d Experience: %d", name, health, level, experience);
	}
}