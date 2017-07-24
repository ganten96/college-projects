/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
/**
 *
 * @author Matthew Zahm
 */
public class LaserTurret extends Turret {
    
    public Laser[] shots;
    public int recharge_duration;
    public int recharge_rate;
    public int recharge_progress;
    public int num_shots;
    public float[] color;
    
    LaserTurret(GameObject owner){
        super(owner);
        
        shots = new Laser[20];
        
        num_shots = 0;
        recharge_duration = 10;
        recharge_rate = 1;
        recharge_progress = 0;
        
    }
        
    public void Fire(){
        // Create a new laser object
        Laser new_shot = new Laser(owner.position.x, 2, owner.position.z,
                                    new Vector3(owner.direction.x, owner.direction.y, owner.direction.z),
                                    3.0,
                                    4, // What Goes here...,
                                    owner.my_playing_field,
                                    owner.drawable,
                                    8.0,
                                    10.0,
                                    10.0,
                                    color
        );
        
        // Update position for the next draw
        shots[num_shots] = new_shot;
        num_shots = (num_shots + 1) % 20;
    }
}
