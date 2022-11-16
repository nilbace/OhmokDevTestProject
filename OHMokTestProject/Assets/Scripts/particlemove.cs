using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleMove : MonoBehaviour {
	ParticleSystem ps;
	ParticleSystem.Particle[] m_Particles;
	public Vector3 target;
	public float speed = 2f;
	private int numParticlesAlive;


    void Start () {
		ps = GetComponent<ParticleSystem>();
		if (!GetComponent<Transform>()){
			GetComponent<Transform>();
		}
	}
    
    
    
	void Update () 
    {
        if(m_Particles == null)
		    m_Particles = new ParticleSystem.Particle[ps.main.maxParticles];

		numParticlesAlive = ps.GetParticles(m_Particles);
	    float step = speed * Time.deltaTime;
		for (int i = 0; i < numParticlesAlive; i++)
        {
			m_Particles[i].position = Vector3.LerpUnclamped(m_Particles[i].position, target, step);

                  
		}

     
        ps.SetParticles(m_Particles, numParticlesAlive);

        
	}
}