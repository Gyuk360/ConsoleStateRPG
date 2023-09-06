using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleStateRPG
{
	class Character
	{
		//Per il momento l'unica caratteristica che il giocatore può scegliere è il nome
		private String name ="";
		//statistiche sono inizzializzate a caso tanto l'algoritmo le ricalcolerà tutte
		private int hp = 1,hpMax = 100;
		private int damage = 1, damageMax = 10;
		private int accuracy = 1;
		private int defence = 1;
		public Character(String name) 
		{
			this.name = name;
			this.CalculateStats();
		}
		private void CalculateStats()
		{
			Random rnd = new Random();
			this.hpMax = 50 + rnd.Next(25,75);
			this.resetHp(); // Fa iniziare il personnaggio con vita attuale pari a quella totale
			this.damage = rnd.Next(3, 7);
			this.damageMax = this.damage * 2; // Ci serve per il colpo critico
			this.accuracy = rnd.Next(6, 10);
			this.defence = rnd.Next(3, 7);
		}

		public int GetHp()
		{
			return hp;
		}

		public int GetHpMax()
		{
			return hpMax;
		}

		public int GetDamage()
		{
			return damage;
		}

		public int GetDamageMax()
		{
			return damageMax;
		}

		public int GetAccuracy()
		{
			return accuracy;
		}

		public int GetDefense()
		{
			return defence;
		}

		public void TakeDamageSetHp(int damageTaken) // Questo è l'unico SET perché ci serve per scalare la vita al personaggio
		{ 
			this.hp = this.hp - damageTaken;
		}

		public void resetHp() 
		{
			this.hp = this.hpMax;
		}


		public override string ToString() //per poter usare una nostra formattazione personalizzata
		{
			String str;
			str = this.name + "\t HP: " + this.hpMax + "\t Forza: " + this.damage + "\t Precisione :" + this.accuracy + "\t Difesa :" + this.defence;
			if (this.accuracy != 6)
			{
				return str;
			}
			else  //Un piccolo easter Egg non manca mai nei miei giochi ;-P
				return "LoL, Good luck bro xD";
		}
	}
}
