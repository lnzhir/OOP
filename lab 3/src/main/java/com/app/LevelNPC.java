package com.app;


import com.app.NonPlayerCharacter;
import com.app.Level;
import java.io.Serializable;
import jakarta.persistence.*;
import lombok.*;



class LevelNPCId implements Serializable {
	private Level level;
	private NonPlayerCharacter NPC;
}


@Getter
@Setter
@NoArgsConstructor(access = AccessLevel.PRIVATE)
@AllArgsConstructor
@Entity
@Table(name = "\"LevelNPCs\"")
@IdClass(LevelNPCId.class)
public class LevelNPC {
	@Id
	@ManyToOne
	@JoinColumn(name = "level_id", nullable = false)
	//@OneToMany(mappedBy = "levelNPCs")
	private Level level;

	@Id
	@ManyToOne
	@JoinColumn(name = "npc_id", nullable = false)
	private NonPlayerCharacter NPC;

	public String toString() {
		//return String.format("Level: '%s' NPC: '%s'", level.getName(), NPC.getName());
		return NPC.toString();
	}
}