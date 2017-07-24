

import java.awt.*;
import java.awt.event.*; 
import com.jogamp.opengl.util.FPSAnimator;
import javax.media.opengl.*;
import javax.media.opengl.glu.*;
import javax.media.opengl.awt.GLJPanel;
import javax.swing.*;
import com.jogamp.opengl.util.gl2.GLUT;
import com.jogamp.opengl.util.texture.TextureIO;
import com.jogamp.opengl.util.texture.*;
import java.io.IOException;
import java.util.Random;

// The Villain currently is a gluQuadric

public class Tree extends GameObject  {
    
    int stun_timer = 0;
    int stun_duration = 200;
    int timer = 0;
    int respawn_time = 250;
    off_file_object off_obj;
    float obj_material [] = { 0.8f, 0.0f, 0.0f, 1.0f };  // Red
    float  specref[] =  { 0.5f, 0.5f, 0.5f, 1.0f };    // material specular reflectance
    int specexp = 128;   // Initalize to maximum falloff factor
    Texture bark_texture = null;
    Texture leaf_texture = null;
    Texture rocket_texture = null;
    LaserTurret main_cannon;
    boolean destroyed = false;
    int rocket_speed;
    
    Tree  (double x, double y, double z,
                        Vector3 direction, 
			double bounding_cir_rad,
			int display_list,
			the_game playing_field,
			GLAutoDrawable drawable,
                        Texture leaf,
                        Texture bark,
                        Texture rocket)

    {
	super (x, y, z, direction, bounding_cir_rad, display_list, playing_field, drawable);
        Random rand = new Random();
        this.name = "tree";
        this.bark_texture = bark;
        this.leaf_texture = leaf;
        this.rocket_texture = rocket;
        rocket_speed = rand.nextInt(6) + 1;
    }

    void draw_self (GLAutoDrawable drawable) {
        if(health < 0 ){
            destroyed = true;
            return;
        }
        GL2 gl = drawable.getGL().getGL2();

        gl.glEnable(GL2.GL_TEXTURE_2D);
                     
        gl.glTexParameteri(GL2.GL_TEXTURE_2D, GL2.GL_TEXTURE_WRAP_S, GL2.GL_CLAMP_TO_EDGE);
        gl.glTexParameteri(GL2.GL_TEXTURE_2D, GL2.GL_TEXTURE_WRAP_T, GL2.GL_CLAMP_TO_EDGE);
        gl.glTexEnvf(GL2.GL_TEXTURE_ENV, GL2.GL_TEXTURE_ENV_MODE, GL2.GL_MODULATE);
        
	gl.glMaterialfv(GL2.GL_FRONT,GL2.GL_AMBIENT , new float[]{1.0f, 1.0f, 1.0f, 1.0f}, 0);
	gl.glMaterialfv(GL2.GL_FRONT,GL2.GL_DIFFUSE , new float[]{1.0f, 1.0f, 1.0f, 1.0f}, 0);
        
	GLU glu = my_playing_field.glu;
	GLUquadric sphere = glu.gluNewQuadric();

	gl.glPushMatrix();
	gl.glTranslated(position.x, 40.0 + rocket_speed * my_playing_field.rocket_timer, position.z );
	gl.glRotated(90.0,  1.0,0.0,0.0);
        //gl.glScaled(scale_factor, scale_factor, scale_factor);
        
        glu.gluQuadricNormals(sphere, GL2.GL_SMOOTH);
        glu.gluQuadricTexture(sphere, true);
        bark_texture.enable(gl);
        bark_texture.bind(gl);
        
        glu.gluCylinder(sphere, bounding_cir_rad * 0.75f, bounding_cir_rad * 0.75f, 60.0f, 15, 15);
        //glu.glCylinder(sphere, bounding_cir_rad, 15, 15);
        bark_texture.disable(gl);
	gl.glPopMatrix();
        
        
	gl.glPushMatrix();
	gl.glTranslated(position.x, 110.0 + rocket_speed * my_playing_field.rocket_timer, position.z );
	gl.glRotated(90.0,  1.0,0.0,0.0);
        //gl.glScaled(scale_factor, scale_factor, scale_factor);
        
        glu.gluQuadricNormals(sphere, GL2.GL_SMOOTH);
        glu.gluQuadricTexture(sphere, true);
        leaf_texture.enable(gl);
        leaf_texture.bind(gl);
        
        glu.gluCylinder(sphere, 0, bounding_cir_rad * 3, 80.0f, 15, 15);
        //glu.glCylinder(sphere, bounding_cir_rad, 15, 15);
        
        leaf_texture.disable(gl);
        
        
	gl.glPopMatrix();gl.glPushMatrix();
	gl.glTranslated(position.x, rocket_speed * my_playing_field.rocket_timer, position.z );
	gl.glRotated(90.0,  1.0,0.0,0.0);
        //gl.glScaled(scale_factor, scale_factor, scale_factor);
        
        glu.gluQuadricNormals(sphere, GL2.GL_SMOOTH);
        glu.gluQuadricTexture(sphere, true);
        rocket_texture.enable(gl);
        rocket_texture.bind(gl);
        
        glu.gluCylinder(sphere, bounding_cir_rad * 0.75f, 0, 80.0f, 15, 15);
        //glu.glCylinder(sphere, bounding_cir_rad, 15, 15);
        
        rocket_texture.disable(gl);
	gl.glPopMatrix();
        
        gl.glTexEnvf(GL2.GL_TEXTURE_ENV, GL2.GL_TEXTURE_ENV_MODE, GL2.GL_DECAL);
        gl.glDisable(GL2.GL_TEXTURE_2D);
        
    }
}