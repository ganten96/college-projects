
import javax.media.opengl.GLAutoDrawable;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
/**
 *
 * @author Matthew Zahm
 */
public abstract class Shot extends GameObject {
    Vector3 direction;
    double speed;
    double damage;
    the_game my_playing_field;
    boolean has_hit;
    
    Shot  (double x, double y, double z,
                Vector3 direction, 
		double bounding_cir_rad,
		int display_list,
		the_game playing_field,
		GLAutoDrawable drawable,
                double speed, 
                double damage)
    {
	super (x, y, z, direction, bounding_cir_rad, display_list, playing_field, drawable);
        
        this.direction = direction;
        this.speed = speed;
        this.damage = damage;
        this.has_hit = false;
    }
    
    @Override
    public boolean Collide(GameObject obj){
        boolean has_collided = false;
        double bounding_size = this.bounding_cir_rad > obj.bounding_cir_rad ? this.bounding_cir_rad : obj.bounding_cir_rad;
        
        if(Distance(obj) < bounding_size){
            obj.TakeDamage(this);
            has_hit = true;
            has_collided = true;
        }
        
        return has_collided;
    }
}
