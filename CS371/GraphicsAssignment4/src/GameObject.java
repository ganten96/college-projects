import java.awt.*;
import java.awt.event.*; 
import com.jogamp.opengl.util.FPSAnimator;
import javax.media.opengl.*;
import javax.media.opengl.glu.*;
import javax.media.opengl.awt.GLJPanel;
import javax.swing.*;
import com.jogamp.opengl.util.gl2.GLUT;

public abstract class GameObject {

    public String name;
    public Vector3 position;
    public Vector3 direction;
    public int degrees;			// Degree measure of direction 
    public double bounding_cir_rad;	// Radius of bounding circle -- to detect collision
    public int my_display_list;
    the_game my_playing_field;
    GLAutoDrawable drawable;
    public boolean can_hold_thingy = true;
    
    // Additions
    public int health;
    public float size;

    GameObject (double x, double y, double z,
		Vector3 direction, 
		double bounding_cir_rad,
		int display_list,
		the_game playing_field,
		GLAutoDrawable drawable)  {
        
        position = new Vector3(x, y, z);
        this.direction = direction;
	this.degrees = degrees;
	this.bounding_cir_rad = bounding_cir_rad;
	my_display_list = display_list;
	my_playing_field = playing_field;
        this.drawable = drawable;
        health = 100;
    }
    
    public boolean Collide(GameObject obj){
        boolean has_collided = false;
        double bounding_size = this.bounding_cir_rad > obj.bounding_cir_rad ? this.bounding_cir_rad : obj.bounding_cir_rad;
        
        if(Distance(obj) < bounding_size){
            has_collided = true;
        }
        
        return has_collided;
    }

    public double Distance(GameObject obj){
        return Math.sqrt(Math.pow(this.position.x - obj.position.x, 2) + Math.pow(this.position.y - obj.position.y, 2) + Math.pow(this.position.z - obj.position.z, 2));
    }
    
    public void TakeDamage(Shot hitting_shot){
        if(my_playing_field.the_thing.carrier == this){
            my_playing_field.the_thing.bounding_cir_rad -= 0.75;
            if(my_playing_field.the_thing.bounding_cir_rad < 2){
                my_playing_field.the_thing.carrier = null;
                my_playing_field.the_thing.bounding_cir_rad = 10;
                can_hold_thingy = false;
            }
        } else {
            this.health -= hitting_shot.damage;
        }
    }
    
    public void strafe(double speed, boolean isLeft)
    {
        //strafe 
        if(!isLeft)
        {
            position = position.AddVec3(direction.RotateAboutY(-Math.PI/2.0).ScalarMult(speed));
        }
        else
        {
            position = position.AddVec3(direction.RotateAboutY(Math.PI/2.0).ScalarMult(speed));
        }
        
        
    }
    
    void turn(double degrees_rotation) {
        direction = direction.RotateAboutY(degrees_rotation);
    }

    // Pass in negative speed for backward motion
    void move(double speed) {	
        //System.out.println(direction.ToString());	
	position.x = position.x + speed * direction.x;
	position.z = position.z + speed * direction.z;
        
        reflect_off_walls();
    }
      
    void reflect_off_walls(){
        // Check to see if a wall was hit and reflect if it was.
        Vector3 normal = new Vector3(0.0, 0.0, 0.0);
        if(position.x >= 1000 - bounding_cir_rad){
            normal = new Vector3(-1.0, 0, 0);
            this.direction = this.direction.SubVec3(normal.ScalarMult(2.0 * normal.DotProduct(this.direction)));
        }
        if(position.x <= bounding_cir_rad){
            normal = new Vector3(1.0, 0, 0);
            this.direction = this.direction.SubVec3(normal.ScalarMult(2.0 * normal.DotProduct(this.direction)));
        }
        if(position.z <= -1000 + bounding_cir_rad){
            normal = new Vector3(0, 0, -1.0);
            this.direction = this.direction.SubVec3(normal.ScalarMult(2.0 * normal.DotProduct(this.direction)));
        }
        if(position.z >= bounding_cir_rad){
            normal = new Vector3(0, 0, 1.0);
            this.direction = this.direction.SubVec3(normal.ScalarMult(2.0 * normal.DotProduct(this.direction)));
        }
    }
    
    abstract void draw_self (GLAutoDrawable drawable); 
}
