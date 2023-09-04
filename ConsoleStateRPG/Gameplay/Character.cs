using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleStateRPG
{
	class Character
	{
		//Caratteristiche di base
		private String name ="";
		private int level =0;
		private int attributePoints =3;
		private int exp =0,expMax =100;
	    //attributi
		private int strenght =1;
		private int vitality = 1;
		private int dexterity = 1;
		private int agility = 1;
		private int intelligence = 1;
		//statistiche sono inizzializzate a caso tanto l'algoritmo le ricalcolerà tutte
		private int hp = 1,hpMax = 100;
		private int damage = 1, damageMax = 10;
		private int accuracy = 1;
		private int defence = 1;
		//inventario
		private int gold = 100;
		public Character(String name) 
		{
			this.name = name;
			this.CalculateStats();
		}

		private void CalculateEXP()
		{
			this.expMax = this.level * 100;
		}
		private void CalculateStats()
		{
			this.hp = this.vitality * 10;
			this.damage = this.strenght;
			this.damageMax = this.strenght * 2;
			this.accuracy = this.dexterity * 2;
			this.defence = this.agility * 2;
		}

		 
		public override string ToString() //per poter usare una nostra formattazione personalizzata
		{
			return this.name;
		}
	}
}
