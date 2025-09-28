package com.app;

import java.lang.Object;
import jakarta.persistence.*;
import lombok.*;



@Getter
@Setter
@NoArgsConstructor(access = AccessLevel.PROTECTED)
@MappedSuperclass
public abstract class Character {
	@Id   
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "id")
	protected int id;

	@Column(name = "name")
	protected String name = "";

	@Column(name = "health")
	protected int health = 1;

	protected Character(String name, int health) {
		this.name = name;
		this.health = health;
	}

	public abstract void sleep(int hours);
	public abstract void death();
}