﻿using System;
using UnityEngine;
//represents genome as an array of integers
public class Genome {

	public char[] genes;
	public string genome;
	private float mutateRate;

	//constructor for first random genotype by length
	public Genome(int length){

		genes = new char[length];
        GenerateRandomGenome(length);
	}

 
    public void GenerateRandomGenome(int length)
    {
        System.Random randomInt = new System.Random();

        //generate a new random genome with genes a-z
        for (int i = 0; i < length; i++)
        {
            int randInt = randomInt.Next(97, 122);
            genes[i] = (char)randInt;
        }
   
        genome = new string(genes);
    }

	//constructor for genome from parent phenotype
	public Genome(string parentGenome){
		
		genome = parentGenome;
		genes = parentGenome.ToCharArray ();

	}

	public int Fitness(string targetString){

		int score = 0;
		for(int i = 0; i < genome.Length; i++) {

			if (genome [i] == targetString [i]) {
				score++;
			}
		}
		return score;
	}

	public override string ToString()
	{
		return genome;
	}

	public double randDist(){

		System.Random rand = new System.Random(); //reuse this if you are generating many
		double u1 = 1.0-rand.NextDouble(); //uniform(0,1] random doubles
		double u2 = 1.0-rand.NextDouble();
		double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
			Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
		double randNormal =	0 + 1 * randStdNormal; //random normal(mean,stdDev^2)
		
		return randNormal;
	}

}
