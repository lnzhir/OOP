package com.app;

import com.app.Character;
import com.app.Level;

import java.util.ArrayList;
import java.util.List;
import jakarta.persistence.*;
import lombok.*;



@Getter
@Setter
@NoArgsConstructor(access = AccessLevel.PRIVATE)
@Entity
@Table(name = "\"NonPlayerCharacters\"")
public class NonPlayerCharacter extends Character {
	private static String[] attitudeStr = {"Friend", "Emeny"};

	@Column(name = "role")
	private String role = "Citizen";

	@Column(name = "attitude")
	private int attitude = 0;

	@ManyToMany(mappedBy = "NPCs")
	/*@ManyToMany(fetch = FetchType.EAGER)
	@JoinTable(
		name = "\"LevelNPCs\""
		, joinColumns = @JoinColumn(name = "npc_id")
		, inverseJoinColumns = @JoinColumn(name = "level_id")
	)*/
	private List<Level> levels = new ArrayList<Level>();


	public NonPlayerCharacter(String name, int health) {
		super(name, health);
	}

	public NonPlayerCharacter(String name, int health, String role, int attitude) {
		super(name, health);
		this.role = role;
		this.attitude = attitude;
	}

	public void setAttitude(int attitude) {
		this.attitude = (attitude <= 0) ? 0 : 1;
	}

	public void panic() {
		System.out.printf("%s panics\n", name);
	}

	public void say(String what) {
		System.out.printf("%s said %s\n", name, what);
	}

	public void sleep(int hours) {
		System.out.printf("%s sleps %d hours\n", name, hours);
	}

	public void death() {
		System.out.printf("%s died\n", name);
	}

	public String toString() {
		return String.format("Name: '%s' Health: %d Role: '%s' Attitude: '%s'", name, health, role, attitudeStr[attitude]);
	}
}