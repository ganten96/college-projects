/*
Forest Space Ball
Authors: Matthew Zahm and Nick Ganter
CS 371 - Computer Graphics - Assignment 4

Goal of the game:
The goal is simple, all you must do is pick up the ball and return it to your 
goal. Each time you do this you score a point, and the first player to 5 points 
wins. The execution, however, may not be so simple. The ruthless villain, a 
klingon bird of prey, is also after the ball and will do whatever it takes to 
get it away from you.

Specifics:
Run over the ball to pick it up and touch the goal to score. Trees block shots
so use them as cover as you run to your goal. The villain is faster than you are
so you must out smart him to have a chance to win.

Both you and the villain have 100 health and a shot does 10 damage. There are no 
health meters so you have to be aware of how many shots you've taken. When you
pickup the ball it creates a shield around you, shots taken while shielded 
damage the shield and visibly shrink it instead of hitting your health. Once 
the shield breaks you are stunned and cannot move but can still shoot back.

There are trees around the arena, they will block your path so either avoid them
or shoot them till they blow up. Trees also have 100 health so 10 shots and they
will vanish.

GGW Features:
Colliding and Destructible Trees - trees stop your movement if you run into them
but have no fear, you can shoot and destroy them to get them out of the way.

Bouncing Bullets - Your bullets will ricochet around the arena using the true
reflection model.

Skybox - A skybox surrounds the arena to give it some more visual appeal.

Combat System - You can shoot and destroy the enemy and he can you shoot and
destroy you.

Respawn System - Both you and the enemy will respawn somewhere near your goal
after you've been destroyed.

*Well Structured Code - The code base has been designed to allow for very easy
expansion of the game's systems. New weapons, multiple villains, and even using 
more than two teams and goals would be quick and easy to add.

*May or may not count toward GGW points, but we're pretty happy with it ;p
*/

import static com.jogamp.newt.event.MouseEvent.PointerType.Mouse;
import java.awt.*;
import java.awt.event.*; 
//import java.util.*;
import com.jogamp.opengl.util.FPSAnimator;
import javax.media.opengl.*;
import javax.media.opengl.glu.*;
import javax.media.opengl.awt.GLJPanel;
import javax.swing.*;
import com.jogamp.opengl.util.gl2.GLUT;
import com.jogamp.opengl.util.texture.TextureIO;
import java.awt.image.BufferedImage;
import com.jogamp.opengl.util.texture.*;
import java.io.IOException;
import java.util.Random;


public class the_game extends JFrame
    implements GLEventListener, KeyListener, MouseMotionListener, MouseWheelListener
{
    static GLU glu;
    static GLUT glut;
    static int xMouseCoord;
    static int yMouseCoord; //so the robot class knows where to reset the mouse.
    static double old_xMouseCoord;
    static double old_yMouseCoord;
    static GLCapabilities caps;
    static FPSAnimator animator;
    static int mouseX, mouseY;
    static float WALLHEIGHT     = 70.0f; // Some playing field parameters
    static float ARENASIZE      = 1000.0f;
    static float EYEHEIGHT      = 15.0f;
    static float HERO_VP        = 0.625f;
    static float zoom_level     = 1.0f;

    static double  upx=0.0, upy=1.0, upz=0.0;    // gluLookAt params 

    static Texture[] skyboxTextures = new Texture[5];
    
    static double fov = 60.0;     // gluPerspective params 
    static double near = 1.0;
    static double far = 10000.0;
    double aspect, eyex, eyez;

    static int width = 1000;       // canvas size 
    static int height = 625;
    static int vp1_left = 0;      // Left viewport -- the hero's view 
    static int vp1_bottom = 0;
    static GLJPanel canvas;
    float ga []  = { 0.2f,0.2f,0.2f, 1.0f }; // global ambient light intensity 
    float la0[]  = { 0.0f,0.0f,0.0f, 1.0f }; // light 0 ambient intensity 
    float ld0[]  = { 1.0f,1.0f,1.0f, 1.0f }; // light 0 diffuse intensity 
    float lp0[]  = { 0.0f,1.0f,1.0f, 0.0f }; // light 0 position 
    float ls0[]  = { 1.0f,1.0f,1.0f, 1.0f }; // light 0 specular 
    float ma []  = { 0.02f , 0.2f  , 0.02f , 1.0f }; // material ambient 
    float md []  = { 0.08f, 0.6f , 0.08f, 1.0f }; // material diffuse 
    float ms []  = { 0.6f  , 0.7f, 0.6f  , 1.0f }; // material specular 
    int me      = 75;             // shininess exponent 
    float red [] = { 1.0f,0.0f,0.0f, 1.0f }; // pure red 
    float blue[] = { 0.0f,0.0f,1.0f, 1.0f }; // pure blue 
    float yellow[] = { 1.0f,1.0f,0.0f, 1.0f }; // pure yellow
    int displayListBase;
    static Team playerOneTeam;
    static Goal playerOneGoal;
    static Team villainTeam;
    static Goal villainGoal;
    static int scoreTimer = 0;
    Texture floor_texture = null;
    char movement_key = ' ';
    Hero  the_hero;		// Three objects on the playing field to 
    ThingWeAreSeeking  the_thing; // start with, each with its own display list.
    Villain  the_villain;	  // Adding more will be good for GGW points

    Tree[] trees = new Tree[60];
    
    boolean player_fired = false;
    int score_limit = 5;
    boolean game_over = false;
    int rocket_timer = 0;
    boolean paused = false;
    
    public the_game() {
	super("the_game");
    }

    public static void main(String[] args) {

        caps = new GLCapabilities(GLProfile.getGL2GL3());
	caps.setDoubleBuffered(true); // request double buffer display mode
	caps.setHardwareAccelerated(true);
	canvas = new GLJPanel();
        the_game myself = new the_game();
        canvas.addGLEventListener(myself);
	canvas.addKeyListener(myself);
        canvas.addMouseMotionListener(myself);
        canvas.addMouseWheelListener(myself);
	animator = new FPSAnimator(canvas, 60);
        JFrame frame = new JFrame("the_game");
        frame.setSize(width,height); // Size in pixels of the frame we draw on
        old_xMouseCoord = xMouseCoord = frame.getWidth() / 2;
        old_yMouseCoord = yMouseCoord = frame.getHeight() / 2;
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.getContentPane().add(canvas);
        frame.setVisible(true);
        Toolkit t = Toolkit.getDefaultToolkit();
        Image i = new BufferedImage(1, 1, BufferedImage.TYPE_INT_ARGB); // this is to hide the mouse cursor.
        Cursor cursor = t.createCustomCursor(i, new Point(0,0), "none");
        frame.setCursor(cursor);
        canvas.requestFocusInWindow();
	myself.run();
    }

    public void run()
    {
	animator.start();
    }
    
    
    public void init(GLAutoDrawable drawable) { 
        
        // Load the texture
        try {
	    floor_texture = TextureIO.newTexture(getClass().getClassLoader().getResourceAsStream("forest.jpg"),
					      false,
					      TextureIO.JPG);
        } catch (IOException e) {
            System.err.println("Caught IOException: " +  e.getMessage());
        }
        
        GL2 gl = drawable.getGL().getGL2();
        glu = new GLU();
        glut = new GLUT();

        try
        {
            skyboxTextures[0] = TextureIO.newTexture(getClass().getClassLoader().getResourceAsStream("siege_back.jpg"), false, TextureIO.JPG); //back
            skyboxTextures[1] = TextureIO.newTexture(getClass().getClassLoader().getResourceAsStream("siege_front.jpg"), false, TextureIO.JPG); //front
            skyboxTextures[2] = TextureIO.newTexture(getClass().getClassLoader().getResourceAsStream("siege_top.jpg"), false, TextureIO.JPG); //top
            skyboxTextures[3] = TextureIO.newTexture(getClass().getClassLoader().getResourceAsStream("siege_left.jpg"), false, TextureIO.JPG); //left
            skyboxTextures[4] = TextureIO.newTexture(getClass().getClassLoader().getResourceAsStream("siege_right.jpg"), false, TextureIO.JPG); //right
        }
        catch(IOException e)
        {
            System.out.println("Unable to load skybox texture.");
        }
	gl.glEnable( GL2.GL_LIGHTING   );
	gl.glEnable( GL2.GL_LIGHT0     );
	gl.glEnable( GL2.GL_LIGHT1     );
	gl.glEnable( GL2.GL_DEPTH_TEST );
	gl.glEnable( GL2.GL_CULL_FACE  );    // Why? 
	eyex  = ARENASIZE/2.0;	// Where the hero starts
	eyez  =  -ARENASIZE + 200;
	displayListBase = gl.glGenLists(4); // Only three currently used for the 3 objects
        //System.out.println("List Base: " + displayListBase);
 	the_hero = new Hero(eyex, 0.0, eyez, 
                                new Vector3(0, 0, 1.0), 
                                10.0, 
                                displayListBase, 
                                this, 
                                drawable);
 	the_thing = new ThingWeAreSeeking(ARENASIZE/2.0, 0.0, -ARENASIZE/2.0, 
                                            new Vector3(1.0, 0, 0), 
                                            10.0,
                                            displayListBase+1, 
                                            this, 
                                            drawable);
 	the_villain = new Villain(ARENASIZE/2.0, 0.0, -200, 
                                    new Vector3(0, 0, 1.0), 
                                    20.0,
                                    displayListBase+2,
                                    this, 
                                    drawable); 

        //Tree Textures
        Texture bark_texture = null;
        Texture leaf_texture = null;
        Texture fire_texture = null;
        try {
	    bark_texture = TextureIO.newTexture(getClass().getClassLoader().getResourceAsStream("HelmsStudios-TreeBark3.jpg"),
					      false,
					      TextureIO.JPG);
        } catch (IOException e) {
            System.err.println("Caught IOException: " +  e.getMessage());
        }
        try {
	    leaf_texture = TextureIO.newTexture(getClass().getClassLoader().getResourceAsStream("pine.jpg"),
					      false,
					      TextureIO.JPG);
        } catch (IOException e) {
            System.err.println("Caught IOException: " +  e.getMessage());
        }
        try {
	    fire_texture = TextureIO.newTexture(getClass().getClassLoader().getResourceAsStream("fire.jpg"),
					      false,
					      TextureIO.JPG);
        } catch (IOException e) {
            System.err.println("Caught IOException: " +  e.getMessage());
        }
        gl.glNewList(displayListBase+3, GL2.GL_COMPILE);
        
	gl.glEndList();
        
        
        Random rand = new Random();
        for(int i = 0; i < trees.length; i++){
            int x_coord = rand.nextInt(900) + 50;
            int z_coord = -(rand.nextInt(900) + 50);
            trees[i] = new Tree(x_coord, 0.0, z_coord, 
                                            new Vector3(1.0, 0, 0), 
                                            10.0,
                                            displayListBase+3, 
                                            this, 
                                            drawable,
                                            leaf_texture,
                                            bark_texture,
                                            fire_texture);
        }
        
                        
        Texture playerGoalTex = null;
        Texture villainGoalTex = null;
        try
        {
            playerGoalTex = TextureIO.newTexture(getClass().getClassLoader().getResourceAsStream("Suelo hierba.jpg"), false, TextureIO.JPG);
            villainGoalTex = TextureIO.newTexture(getClass().getClassLoader().getResourceAsStream("Suelo tierra.jpg"), false, TextureIO.JPG);
        }
        catch(IOException ex)
        {
            System.out.println("Unable to load goal texture");
        }
        playerOneTeam = new Team(new float[] {0.0f, 0.0f, 1.0f}, "Hero", 0);
        playerOneGoal = new Goal(ARENASIZE/2.0, 0,-ARENASIZE + 100, new Vector3(1.0, 0.0,0.0), 10, displayListBase+4, this, drawable, playerOneTeam, playerOneTeam.color, playerGoalTex);
	villainTeam = new Team(new float[]{1.0f, 0.0f, 0.0f}, "Villain", 0);
        villainGoal = new Goal(ARENASIZE/2.0, 0, -100, new Vector3(1.0, 0.0,0.0), 10, displayListBase+5, this, drawable, villainTeam, villainTeam.color, villainGoalTex);

	aspect=(double)width/(double)height;

        
	gl.glLightfv(GL2.GL_LIGHT0, GL2.GL_AMBIENT , la0, 0);
	gl.glLightfv(GL2.GL_LIGHT0, GL2.GL_DIFFUSE , ld0, 0);
	gl.glLightfv(GL2.GL_LIGHT0, GL2.GL_SPECULAR, ls0, 0);
	gl.glLightfv(GL2.GL_LIGHT0,GL2.GL_POSITION,  lp0, 0);
	gl.glLightModelfv(GL2.GL_LIGHT_MODEL_AMBIENT, ga, 0);
                
//	gl.glLightfv(GL2.GL_LIGHT1, GL2.GL_POSITION,  new float[]{(float)ARENASIZE/4.0f, 20.0f, -(float)ARENASIZE/4.0f}, 0);
//	gl.glLightfv(GL2.GL_LIGHT1, GL2.GL_AMBIENT , new float[]{ 0.0f, 0.0f, 1.0f, 1.0f }, 0);
//	gl.glLightfv(GL2.GL_LIGHT1, GL2.GL_DIFFUSE , new float[]{ 1.0f, 1.0f, 1.0f, 1.0f }, 0);
//	gl.glLightfv(GL2.GL_LIGHT1, GL2.GL_SPECULAR, new float[]{ 0.0f, 0.0f, 1.0f, 1.0f }, 0);
//	gl.glLightfv(GL2.GL_LIGHT1, GL2.GL_SPOT_DIRECTION, new float[]{ 0.0f, -1.0f, 0.0f, 1.0f }, 0);
//	gl.glLightf(GL2.GL_LIGHT1, GL2.GL_SPOT_CUTOFF, 45.0f);
//	gl.glLightf(GL2.GL_LIGHT1, GL2.GL_SPOT_EXPONENT, 10.0f);

	gl.glShadeModel(GL2.GL_SMOOTH);
        
        try
        {
            Robot r = new Robot();
            if(canvas.hasFocus())
            {
                r.mouseMove(xMouseCoord, yMouseCoord);
            }
        }
        catch(AWTException ex)
        {
            System.out.println("Unable to start mouse robot.");
        }
        
    }
    
    public void display(GLAutoDrawable drawable) { 
        if(!game_over){
            scoreTimer++;
        } else {
            rocket_timer++;
        }
        GL2 gl = drawable.getGL().getGL2();
        if(scoreTimer > 260)
        {
            gl.glDisable(GL2.GL_LIGHT1);
            scoreTimer = 0;
        }
	int horiz_offset, vert_offset;
        try
        {
            Robot r = new Robot();
            if(canvas.hasFocus())
            {
                r.mouseMove(xMouseCoord, yMouseCoord);
            }
        }
        catch(AWTException e)
        {
            System.out.println("Unable to start Robot.");
            e.printStackTrace();
        }
        
        
	gl.glClearColor( 0.4f,0.4f,0.4f, 1.0f );
	gl.glClear ( GL2.GL_DEPTH_BUFFER_BIT | GL2.GL_COLOR_BUFFER_BIT );
        
        
        // Score viewport
	horiz_offset = (int) (width * (1.0 - HERO_VP) / 6.0);
	vert_offset = height / 6;
	gl.glViewport( vp1_left + (int) (HERO_VP * width) + horiz_offset ,
		       vp1_bottom + 5 * vert_offset + 10, 
                       4 * horiz_offset, 
                       0 );
	gl.glMatrixMode( GL2.GL_PROJECTION );
	gl.glLoadIdentity();
	gl.glOrtho( -100,100, -100,100, 0,200);

	gl.glMatrixMode( GL2.GL_MODELVIEW );
	gl.glLoadIdentity();
	glu.gluLookAt( 100.,100.,-100.,  100.,0.,-100.,  0.,0.,-1. );
        
        gl.glDisable(gl.GL_LIGHTING);
        
        gl.glColor3f(1.0f, 1.0f, 1.0f);
        gl.glRasterPos2d(75, 100);
        glut.glutBitmapString(GLUT.BITMAP_TIMES_ROMAN_24,  "Score");
        gl.glColor3f(0, 1.0f, 0);
        gl.glRasterPos2d(25, 100);
        glut.glutBitmapString(GLUT.BITMAP_TIMES_ROMAN_24,  playerOneTeam.score + "");
        gl.glColor3f(1.0f, 0, 0);
        gl.glRasterPos2d(150, 100);
        glut.glutBitmapString(GLUT.BITMAP_TIMES_ROMAN_24,  villainTeam.score + "");
        
        gl.glEnable(gl.GL_LIGHTING);
        
        
	// Hero's eye viewport 
	gl.glViewport( vp1_left, vp1_bottom, (int) (HERO_VP * width), height );
	gl.glMatrixMode( GL2.GL_PROJECTION );
	gl.glLoadIdentity();
	glu.gluPerspective( fov, HERO_VP * aspect, near, far );

	gl.glMatrixMode( GL2.GL_MODELVIEW );
	gl.glLoadIdentity();
	glu.gluLookAt(the_hero.position.x - (the_hero.direction.x * 50) * zoom_level, EYEHEIGHT + 15 * zoom_level, the_hero.position.z - (the_hero.direction.z * 50)  * zoom_level,
		     the_hero.position.x + the_hero.direction.x, EYEHEIGHT, the_hero.position.z + the_hero.direction.z,
		     upx, upy, upz);
	        
        // Draw game objects
        showArena (drawable);
	showObjects(drawable);
        draw_shots(drawable);
        
	// Overhead viewport 
	gl.glViewport( vp1_left + (int) (HERO_VP * width) + horiz_offset ,
		       vp1_bottom + vert_offset, 4 * horiz_offset, 4 * vert_offset );
	gl.glMatrixMode( GL2.GL_PROJECTION );
	gl.glLoadIdentity();
	gl.glOrtho( -500,500, -500,500, 0,200);

	gl.glMatrixMode( GL2.GL_MODELVIEW );
	gl.glLoadIdentity();
	glu.gluLookAt( 500.,100.,-500.,  500.,0.,-500.,  0.,0.,-1. );
        
        // Draw game objects
	showArena (drawable);
	showObjects(drawable);
        draw_shots(drawable);
        
        // Hero/Villain shooting
            if(player_fired){
                // Hero can fire if his recharge is 
                if(the_hero.main_cannon.recharge_progress >= the_hero.main_cannon.recharge_duration){
                    the_hero.main_cannon.Fire();
                    player_fired = false;
                    the_hero.main_cannon.recharge_progress = 0;
                }
            }

        if(!paused){
            // Villain can fire if his recharge is finished, he's not stunned, and he's not respawning.
            if(the_villain.main_cannon.recharge_progress >= the_villain.main_cannon.recharge_duration && the_villain.stun_timer <= 2 && the_villain.timer <= 2){
                the_villain.main_cannon.Fire();
                the_villain.main_cannon.recharge_progress = 0;
            }
        }
        
        // Hero/Villain Moving       
        move_hero(drawable);
        move_villain(drawable);
        
	gl.glFlush();
    }
    
    public void move_villain(GLAutoDrawable drawable){
        GL2 gl = drawable.getGL().getGL2();
        the_villain.Collide(the_thing);
        boolean hit_hero = the_villain.Collide(the_hero);
        the_villain.main_cannon.recharge_progress += the_villain.main_cannon.recharge_rate;
        for(int i = 0; i < trees.length; i++){
            if(!trees[i].destroyed){
                the_villain.Collide(trees[i]);
            }
        }
        
        if(the_thing.carrier != null && the_thing.carrier.equals(the_villain))
        {
            boolean hasScored = the_villain.Collide(villainGoal);
            if(hasScored)
            {
                villainGoal.scored(villainTeam);
                the_thing.respawn();
                gl.glLightfv(GL2.GL_LIGHT1, GL2.GL_POSITION,  new float[]{(float)ARENASIZE/4.0f, 20.0f, -(float)ARENASIZE/4.0f}, 0);
            	gl.glLightfv(GL2.GL_LIGHT1, GL2.GL_AMBIENT , villainTeam.color, 0);
                gl.glEnable(GL2.GL_LIGHT1);
                
                if(villainTeam.score == score_limit){
                    game_over = true;
                    paused = true;
                }
            }
        }
        
        if(the_thing.carrier != the_villain){
            
            // Update direction to seek the thing
            Vector3 direction_to_thing = the_thing.position.SubVec3(the_villain.position);
            direction_to_thing = direction_to_thing.Normalize();
            
            if(!direction_to_thing.IsZero()){
                the_villain.direction = direction_to_thing;
            } 
            
            // Move the villain if he's not stunned
            if(the_villain.can_hold_thingy && !hit_hero){
                if(!paused){
                    the_villain.move(2.5);
                }
            } else {
                // Turn to the player to shoot it
                Vector3 direction_to_player = the_hero.position.SubVec3(the_villain.position);
                direction_to_player = direction_to_player.Normalize();
                
                if(!direction_to_player.IsZero() && !paused){
                    the_villain.direction = direction_to_player;
                } 
            }
        } else {
            // Run to the goal
            Vector3 direction_to_goal = villainGoal.position.SubVec3(the_villain.position);
            direction_to_goal = direction_to_goal.Normalize();
            if(!direction_to_goal.IsZero() && !paused){
                the_villain.direction = direction_to_goal;
            } 
            
            if(!paused){
                the_villain.move(2.0);
            }
        }
    }
    
    public void move_hero(GLAutoDrawable drawable){
        GL2 gl = drawable.getGL().getGL2();
        the_hero.Collide(the_thing);
        the_hero.Collide(the_villain);
        the_hero.main_cannon.recharge_progress += the_hero.main_cannon.recharge_rate;
        for(int i = 0; i < trees.length; i++){
            if(!trees[i].destroyed && !game_over){
                the_hero.Collide(trees[i]);
            }
        }
        if(the_thing.carrier != null && the_thing.carrier.equals(the_hero))
        {
            boolean hasScored = the_hero.Collide(playerOneGoal);
            if(hasScored)
            {
                playerOneGoal.scored(playerOneTeam);
                the_thing.respawn();
                gl.glLightfv(GL2.GL_LIGHT1, GL2.GL_POSITION,  new float[]{(float)ARENASIZE/4.0f, 20.0f, -(float)ARENASIZE/4.0f}, 0);
            	gl.glLightfv(GL2.GL_LIGHT1, GL2.GL_AMBIENT , playerOneTeam.color, 0);
                gl.glEnable(GL2.GL_LIGHT1);
                
                if(playerOneTeam.score == score_limit){
                    game_over = true;
                    paused = true;
                }
            }
        }
        
        if(movement_key != ' ' && the_hero.stun_timer == 0){
            switch(movement_key){
	    case 's':
		// Move backward
		the_hero.move(-2.0);
		break;
	    case 'w':
		// Move forward
                the_hero.move(2.0);
		break;
	    case 'a':
		// strafe left 
		the_hero.strafe(2.0, true);
		break;
	    case 'd':
		// strafe right 
		the_hero.strafe(2.0, false);
		break;
            }
        }
    }
    
    public void draw_shots(GLAutoDrawable drawable){
        // Hero Shots
        for(Shot s : the_hero.main_cannon.shots){
            if(s != null && !s.has_hit){
                s.Collide(the_villain);
                
                for(int i = 0; i < trees.length; i++){
                    if(!trees[i].destroyed){
                        s.Collide(trees[i]);
                    }
                }
                
                s.move(s.speed);
                s.draw_self(drawable);
            }
        }
        
        // Villain Shots
        for(Shot s : the_villain.main_cannon.shots){
            if(s != null && !s.has_hit){
                s.Collide(the_hero);
                
                for(int i = 0; i < trees.length; i++){
                    if(!trees[i].destroyed){
                        s.Collide(trees[i]);
                    }
                }
                
                if(!paused){
                    s.move(s.speed);
                }
                s.draw_self(drawable);
            }
        }
    }
    
    public void reshape(GLAutoDrawable drawable, int x, int y, int w, int h) {                
	width = w;
	height = h;
	aspect=(double)width/(double)height;
        xMouseCoord = width / 2;
        yMouseCoord = height / 2;
    }
    
    public void displayChanged(GLAutoDrawable drawable, boolean modeChanged,
			       boolean deviceChanged) { // Nothing for us to do here
    }


    void showArena(GLAutoDrawable drawable)
    {
        
        GL2 gl = drawable.getGL().getGL2();
        drawSkybox(gl, skyboxTextures);
        
	gl.glMaterialfv(GL2.GL_FRONT,GL2.GL_AMBIENT  , ma, 0);
	gl.glMaterialfv(GL2.GL_FRONT,GL2.GL_DIFFUSE  , md, 0);
	gl.glMaterialfv(GL2.GL_FRONT,GL2.GL_SPECULAR , ms, 0);
	gl.glMateriali (GL2.GL_FRONT,GL2.GL_SHININESS, me);
       
        gl.glEnable(GL.GL_BLEND);
        gl.glBlendFunc (GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);
	
        
        gl.glColor4f(1.0f, 1.0f, 1.0f, 0.0f);
        
        gl.glPushMatrix();
	gl.glBegin(GL2.GL_POLYGON);
	gl.glNormal3f( 1.0f,0.0f,0.0f );
	gl.glVertex3f(0.0f,0.0f,0.0f);
	gl.glVertex3f(0.0f,0.0f,-ARENASIZE);
	gl.glVertex3f(0.0f,WALLHEIGHT,-ARENASIZE);
	gl.glVertex3f(0.0f,WALLHEIGHT,0.0f); 
	gl.glEnd();
        
	gl.glBegin(GL2.GL_POLYGON);
	gl.glNormal3f( -1.0f,0.0f,0.0f );
	gl.glVertex3f(ARENASIZE,0.0f,0.0f);
	gl.glVertex3f(ARENASIZE,WALLHEIGHT,0.0f);
	gl.glVertex3f(ARENASIZE,WALLHEIGHT,-ARENASIZE);
	gl.glVertex3f(ARENASIZE,0.0f,-ARENASIZE);
	gl.glEnd();

	gl.glBegin(GL2.GL_POLYGON);
	gl.glNormal3f( 0.0f,0.0f,1.0f );
	gl.glVertex3f(0.0f,0.0f,-ARENASIZE);
	gl.glVertex3f(ARENASIZE,0.0f,-ARENASIZE);
	gl.glVertex3f(ARENASIZE,WALLHEIGHT,-ARENASIZE);
	gl.glVertex3f(0.0f,WALLHEIGHT,-ARENASIZE);
	gl.glEnd();

	gl.glBegin(GL2.GL_POLYGON);
	gl.glNormal3f( 0.0f,0.0f,-1.0f );
	gl.glVertex3f(0.0f,0.0f,0.0f);
	gl.glVertex3f(0.0f,WALLHEIGHT,0.0f);
	gl.glVertex3f(ARENASIZE,WALLHEIGHT,0.0f);
	gl.glVertex3f(ARENASIZE,0.0f,0.0f);
	gl.glEnd();

	gl.glPopMatrix();
        
        drawSkybox(gl, skyboxTextures);
        gl.glDisable(GL.GL_BLEND);
        gl.glEnable(GL2.GL_TEXTURE_2D);
                     
        gl.glTexParameteri(GL2.GL_TEXTURE_2D, GL2.GL_TEXTURE_WRAP_S, GL2.GL_CLAMP_TO_EDGE);
        gl.glTexParameteri(GL2.GL_TEXTURE_2D, GL2.GL_TEXTURE_WRAP_T, GL2.GL_CLAMP_TO_EDGE);
        gl.glTexEnvf(GL2.GL_TEXTURE_ENV, GL2.GL_TEXTURE_ENV_MODE, GL2.GL_MODULATE );
        gl.glTexParameteri(GL2.GL_TEXTURE_2D, GL2.GL_TEXTURE_MAG_FILTER, GL2.GL_LINEAR);
        gl.glTexParameteri(GL2.GL_TEXTURE_2D, GL2.GL_TEXTURE_MIN_FILTER, GL2.GL_LINEAR);
         
        floor_texture.enable(gl);
        floor_texture.bind(gl);
        // Floor
	gl.glMaterialfv(GL2.GL_FRONT,GL2.GL_AMBIENT , new float[]{ 0.7f, 0.7f, 0.7f, 1.0f }, 0);
	gl.glMaterialfv(GL2.GL_FRONT,GL2.GL_DIFFUSE , new float[]{ 0.7f, 0.7f, 0.7f, 1.0f }, 0);
	gl.glBegin(GL2.GL_POLYGON);
	gl.glNormal3f( 0.0f,1.0f,0.0f );
        gl.glTexCoord2f(0.0f, 0.0f);
	gl.glVertex3f(0.0f,0.0f,0.0f);
        gl.glTexCoord2f(1.0f, 0.0f);
	gl.glVertex3f(ARENASIZE,0.0f,0.0f);
        gl.glTexCoord2f(1.0f, 1.0f);
	gl.glVertex3f(ARENASIZE,0.0f,-ARENASIZE);
        gl.glTexCoord2f(0.0f, 1.0f);
	gl.glVertex3f(0.0f,0.0f,-ARENASIZE);
	gl.glEnd();

        floor_texture.disable(gl);
        gl.glDisable(GL2.GL_TEXTURE_2D);

    }

    void showObjects(GLAutoDrawable drawable)
    {
        
        GL2 gl = drawable.getGL().getGL2();
	the_thing.draw_self(drawable);
	the_hero.draw_self(drawable);
        
        the_villain.draw_self(drawable);
        for(int i = 0; i < trees.length; i++){
            trees[i].draw_self(drawable);
        }
        
        playerOneGoal.draw_self(drawable);
        villainGoal.draw_self(drawable);
        
    }

    public void dispose(GLAutoDrawable arg0) { // GLEventListeners must implement
    }

    /////////////////////////////////////////////////////////////////
    // Methods in the KeyListener interface are keyTyped, keyPressed,
    // keyReleased.  Listeners should affect the animation by changing
    // state variables, NOT by directory making calls to GL graphic
    // methods -- that should be left for the display method.

    public void keyTyped(KeyEvent key)
    {
    }

    public void drawSkybox(GL2 gl, Texture[] skybox)
    {
        //0 back 1 front 2 top 3 left 4 right
        gl.glTexParameteri(GL2.GL_TEXTURE_2D, GL2.GL_TEXTURE_WRAP_S, GL2.GL_CLAMP);
        gl.glTexParameteri(GL2.GL_TEXTURE_2D, GL2.GL_TEXTURE_WRAP_T, GL2.GL_CLAMP);
        gl.glPushAttrib(GL2.GL_ENABLE_BIT);
        gl.glEnable(GL2.GL_TEXTURE_2D);
        gl.glDisable(GL2.GL_DEPTH_TEST);
        gl.glDisable(GL2.GL_LIGHTING);
        gl.glDisable(GL2.GL_BLEND);
        gl.glColor4f(1.0f, 1.0f, 1.0f, 1.0f);
        skybox[1].enable(gl);//render the front quad.
        skybox[1].bind(gl);
        gl.glBegin(GL2.GL_QUADS);
            gl.glTexCoord2f(0, 0); 
            gl.glVertex3f(0.0f, 0.0f, -ARENASIZE);
            gl.glTexCoord2f(1, 0); 
            gl.glVertex3f(ARENASIZE,  0.0f, -ARENASIZE );
            gl.glTexCoord2f(1, 1); 
            gl.glVertex3f(ARENASIZE, 512.0f, -ARENASIZE);
            gl.glTexCoord2f(0, 1); 
            gl.glVertex3f(0.0f, 512.0f, -ARENASIZE );
       gl.glEnd();
       skybox[0].enable(gl);//render the back quad.
       skybox[0].bind(gl);
        gl.glBegin(GL2.GL_QUADS);
            gl.glTexCoord2f(0, 0); 
            gl.glVertex3f(ARENASIZE, 0.0f, 0.0f);
            gl.glTexCoord2f(1, 0); 
            gl.glVertex3f(0.0f,  0.0f, 0.0f );
            gl.glTexCoord2f(1, 1); 
            gl.glVertex3f(0.0f, 512.0f, 0.0f);
            gl.glTexCoord2f(0, 1); 
            gl.glVertex3f(ARENASIZE, 512.0f, 0.0f );
       gl.glEnd();
       skybox[2].enable(gl);//render the top quad.
       skybox[2].bind(gl);
       gl.glBegin(GL2.GL_QUADS);
        gl.glTexCoord2f(0.0f, 0.0f);
	gl.glVertex3f(0.0f,512.0f,0.0f);
        gl.glTexCoord2f(1.0f, 0.0f);
	gl.glVertex3f(0.0f,512.0f,-ARENASIZE);
        gl.glTexCoord2f(1.0f, 1.0f);
        gl.glVertex3f(ARENASIZE, 512.0f, -ARENASIZE);
        gl.glTexCoord2f(0.0f, 1.0f);
	gl.glVertex3f(ARENASIZE, 512.0f, 0.0f);
       gl.glEnd();
       skybox[3].enable(gl);//render the left quad.
       skybox[3].bind(gl);
       gl.glBegin(GL2.GL_QUADS);
        gl.glTexCoord2f(0.0f, 0.0f);
	gl.glVertex3f(0.0f,0.0f,0.0f);
        gl.glTexCoord2f(1.0f, 0.0f);
	gl.glVertex3f(0.0f,0.0f,-ARENASIZE);
        gl.glTexCoord2f(1.0f, 1.0f);
	gl.glVertex3f(0.0f,512.0f,-ARENASIZE);
        gl.glTexCoord2f(0.0f, 1.0f);
	gl.glVertex3f(0.0f,512.0f,0.0f);
       gl.glEnd();
        skybox[4].enable(gl);//render the right quad.
        skybox[4].bind(gl);
        gl.glBegin(GL2.GL_QUADS);
            gl.glTexCoord2f(0.0f, 0.0f); 
            gl.glVertex3f(ARENASIZE, 0.0f, -ARENASIZE);
            gl.glTexCoord2f(1.0f, 0.0f); 
            gl.glVertex3f(ARENASIZE, 0.0f,  0.0f);
            gl.glTexCoord2f(1.0f, 1.0f); 
            gl.glVertex3f(ARENASIZE, 512.0f, 0.0f);
            gl.glTexCoord2f(0.0f, 1.0f); 
            gl.glVertex3f(ARENASIZE, 512.0f, -ARENASIZE);
       gl.glEnd();
       gl.glPopAttrib();
    }
    
    public void keyPressed(KeyEvent key)
    {
        switch (key.getKeyCode()) {
            case KeyEvent.VK_UP :
                zoom_level = zoom_level - 0.1f < 0 ? 0 : zoom_level - 0.1f;
                break;
            case KeyEvent.VK_DOWN :
                zoom_level = zoom_level + 0.1f > 2.0f ? 2.0f : zoom_level + 0.1f;
                break;
            default:
                break;
        }
        
	char ch = key.getKeyChar();
	//System.out.println(ch);
	switch(ch)
	    {
	    case 27:
		new Thread()
		{
		    public void run()
		    {
			animator.stop();
		    }
		}.start();
		System.exit(0);
		break;
	    case ' ':
                player_fired = true;
		break;
	    case 's':
		// Move backward
                movement_key = 's';
		break;
	    case 'w':
		// Move forward
                movement_key = 'w';
		break;
	    case 'a':
		// strafe left 
                movement_key = 'a';
		break;
	    case 'd':
		// strafe right 
                movement_key = 'd';
		break;
            case 'q':
                //turn left
                the_hero.turn(Math.PI/30);
                break;
            case 'e':
                //turn right
                the_hero.turn(-Math.PI/30);
                break;
            case 'p':
                paused = !paused;
                break;
	    default:
		break;
	    }

    }
    
    @Override
    public void mouseDragged(MouseEvent e) 
    {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    
    public void mouseWheelMoved(MouseWheelEvent e){
        int wheel_direction = e.getWheelRotation();
        zoom_level = zoom_level + 0.1f * wheel_direction < 0 ? 0 : zoom_level + 0.1f * wheel_direction;
    }
    
    @Override
    public void mouseMoved(MouseEvent e) 
    {
        double xPos = e.getX();
        double yPos = e.getY();
        
        if(xPos < xMouseCoord - 8)
        {
            the_hero.turn(Math.PI/60);
        }
        else if(xPos > xMouseCoord  - 8)
        {
            the_hero.turn(-Math.PI/60);
        }
        
        //System.out.println("xPos: " + xPos + "  yPos: " + yPos);
    }
    
    public void keyReleased(KeyEvent key)
    {
        char ch = key.getKeyChar();
	switch(ch)
        {
            case 's':
            case 'w':
            case 'a':
            case 'd':
                movement_key = ' ';
            default:
                break;
        }
    }
}
