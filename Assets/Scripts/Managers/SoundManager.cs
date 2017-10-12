using UnityEngine;
using System.Collections;

public class SoundManager : SingeltonBase<SoundManager>
{
    /* -------------- 	Game specific sounds --------------- */
    public AudioClip levelUpSound;
    // Done
    public AudioClip buttonClickSound;
    // with menus
    public AudioClip menuBGSound;
    // Done
    public AudioClip gamePlayBGSound;
    // Done
    public AudioClip levelCompleteSound;
    // Done
    public AudioClip levelFailSound;
    // Done
    public AudioClip upgradeSound;
    // family and evolve menus
    public AudioClip doorOpeningSound;
    // family and evolve menus

    /* -------------- 	Nature specific sounds --------------- */

    public AudioClip nightBGSound;
    //Assign to gameplayBGSound, when night.
    public AudioClip thunderSound;
    // Play on night occasionaly.
    public AudioClip rainSound;
    // Play on night continuesly.
    public AudioClip fallingRockSound;
    // Play on night occasionaly.
	
    /* -------------- 	Player specific sounds --------------- */
    public AudioClip playerRunSound;
    public AudioClip playerAttackSound;
    public AudioClip playerEatSound;
    public AudioClip hitSound;
    public AudioClip playerHitSound;
    public AudioClip playerLastAttackSound;

    public AudioClip gorillaRoar;
    public AudioClip thud;
	

    /* -------------- 	Humans  --------------- */
    public AudioClip man;
    public AudioClip boy;
    public AudioClip girl;
    public AudioClip maleScream;
    public AudioClip femaleScream;

    /* -------------- 	Collectibles  --------------- */
	
    /* -------------- 	Breakable Items  --------------- */

    /* -------------- 	Non-Living Objects  --------------- */

    /* -------------- 	Animals --------------- */

    public AudioClip humanDeath;

    //////////////////////////////////////////////////////////
    /* -------------- 	Others  --------------- */
    public AudioClip waterSplashSound;
    public AudioClip machineGunShot;
    public AudioClip rifleGunShot;
    public AudioClip fenceDrop;
    public AudioClip woodenObjectDrop;
    public AudioClip oilTankExplosion;
    public AudioClip rocketExplosion;
    public AudioClip rocketLaunch;
    public AudioClip treeFall;
    public AudioClip poleFall;
    public AudioClip carHit, carHit2;
    public AudioClip challengeArea;
    public AudioClip punch;
    public AudioClip stomp;
    public AudioClip Alien_bullet_Fire1;
    public AudioClip Alien_bullet_Fire2;
    public AudioClip Alien_death_1;
    public AudioClip Alien_death_2;
    public AudioClip Alien_FireBall;
    public AudioClip Player_FireBall;
	
    public AudioClip rockman_completion_sound;
    public AudioClip thunderman_completion_sound;
    public AudioClip firegirl_completion_sound;
	
	
	
	
    /* Audio Source */
    public AudioSource gamePlayEffectsSource;
    public AudioSource BackgroundSoundSource;
    public AudioSource CarEnvSound;
    public AudioSource rainthunderSoundSource;
    public AudioSource runSoundSource;
    public AudioSource healthSoundSource;
	


    public bool isDualSound = false;
    private bool isGamePlaySound = false;

    void Start()
    {
		
        DontDestroyOnLoad(this);
        if (isDualSound)
        {
            this.GetComponent<AudioSource>().clip = menuBGSound;
            isGamePlaySound = false;
        }
        else
        {
            this.GetComponent<AudioSource>().clip = gamePlayBGSound;
            isGamePlaySound = true;
        }
        if (!UserPrefs.isSound)
        {
            this.GetComponent<AudioSource>().mute = true;
            gamePlayEffectsSource.mute = true;
            BackgroundSoundSource.mute = true;
            CarEnvSound.mute = true;
            runSoundSource.mute = true;
            healthSoundSource.mute = true;
        }
        if (!this.GetComponent<AudioSource>().isPlaying)
        {
            this.GetComponent<AudioSource>().Play();
        }		
    }

    public void playHumanSound(int soundEffectID)
    {
        switch (soundEffectID)
        {
            case 0:
                gamePlayEffectsSource.PlayOneShot(man);
                break;
            case 1:
                gamePlayEffectsSource.PlayOneShot(boy);
                break;
            case 2:
                gamePlayEffectsSource.PlayOneShot(girl);
                break;
        }
    }

    public void playBreakableSound(int soundEffectID)
    {
        if (!gamePlayEffectsSource.isPlaying)
            gamePlayEffectsSource.PlayOneShot(hitSound);
    }

    public void playPlayerSound(int soundEffectID)
    {
		
    }

    public void playNPCSound(int soundeffect)
    {
		
    }

    public void playOtherSound(int soundEffectID)
    {
		
    }

    public void PlaySound(GameManager.SoundState state)
    {
        if (!UserPrefs.isSound)
            return;
        
        switch (state)
        {
            case GameManager.SoundState.HUMANKILLSOUND:
                this.humanDeathSound();
                break;
            case GameManager.SoundState.LASTATTACKSOUND:
                this.playerLastAttack();
                break;

            case GameManager.SoundState.BUTTONCLICKSOUND:
                this.ButtonClickSound();
                break;
            case GameManager.SoundState.MUTESOUND:
                this.MuteSound();
                break;
            case GameManager.SoundState.UNMUTESOUND:
                this.UnMuteSound();
                break;

            case GameManager.SoundState.MUTEMUSIC:
                this.MuteMusic();
                break;
            case GameManager.SoundState.UNMUTEMUSIC:
                this.UnMuteMusic();
                break;

            case GameManager.SoundState.LEVELUPSOUND:
                gamePlayEffectsSource.PlayOneShot(levelUpSound);
                break;

            case GameManager.SoundState.PLAYERRUNSOUND:
                if (!gamePlayEffectsSource.isPlaying)
                    gamePlayEffectsSource.PlayOneShot(playerRunSound);
                break;
	
            case GameManager.SoundState.PLAYERATTACKSOUND:
                gamePlayEffectsSource.PlayOneShot(playerAttackSound);
                break;
            case GameManager.SoundState.DIGSOUND:
//			gamePlayEffectsSource.PlayOneShot(digSound);
                break;
            case GameManager.SoundState.WATERSPLASHSOUND:
                gamePlayEffectsSource.PlayOneShot(waterSplashSound);
                break;

            case GameManager.SoundState.DOOR_OPENING_SOUND:
                gamePlayEffectsSource.PlayOneShot(doorOpeningSound);
                break;
	
            case GameManager.SoundState.HITSOUND:
                gamePlayEffectsSource.PlayOneShot(hitSound);
                break;
            case GameManager.SoundState.PLAYERHITSOUND:
                gamePlayEffectsSource.PlayOneShot(playerHitSound);
                break;
            case GameManager.SoundState.UPGRADESOUND:
                gamePlayEffectsSource.PlayOneShot(upgradeSound);
                break;
            case GameManager.SoundState.THUNDERSOUND:
                gamePlayEffectsSource.PlayOneShot(thunderSound);
                break;
            case GameManager.SoundState.FALLING_ROCK_SOUND:
                gamePlayEffectsSource.PlayOneShot(fallingRockSound);
                break;
            case GameManager.SoundState.RAINSOUND:
                this.playRainSound();
                break;
            case GameManager.SoundState.LEVELCOMPLETIONSOUND:
                gamePlayEffectsSource.PlayOneShot(levelCompleteSound);
                break;
            case GameManager.SoundState.LEVELFAIL:
                gamePlayEffectsSource.PlayOneShot(levelFailSound);
                break;

            case GameManager.SoundState.PLAYEREATSOUND:
                gamePlayEffectsSource.PlayOneShot(playerEatSound);
                break;
            case GameManager.SoundState.GUNSHOT:
                gamePlayEffectsSource.PlayOneShot(rifleGunShot);
                break;
            case GameManager.SoundState.PUNCHSOUND:
                gamePlayEffectsSource.PlayOneShot(punch);
                break;
            case GameManager.SoundState.STOMPSOUND:
                gamePlayEffectsSource.PlayOneShot(stomp);
                break;
            case GameManager.SoundState.ROARSOUND:
                gamePlayEffectsSource.PlayOneShot(gorillaRoar);
                break;
            case GameManager.SoundState.THUDSOUND:
                gamePlayEffectsSource.PlayOneShot(thud);
                break;
            case GameManager.SoundState.ALIENBULLET1:
                gamePlayEffectsSource.PlayOneShot(Alien_bullet_Fire1);
                break;
            case GameManager.SoundState.ALIENBULLET2:
                gamePlayEffectsSource.PlayOneShot(Alien_bullet_Fire2);
                break;
            case GameManager.SoundState.ALIENDEATH1:
                gamePlayEffectsSource.PlayOneShot(Alien_death_1);
                break;
            case GameManager.SoundState.ALIENDEATH2:
                gamePlayEffectsSource.PlayOneShot(Alien_death_2);
                break;
            case GameManager.SoundState.PLAYER_FIREBALL:
                gamePlayEffectsSource.PlayOneShot(Player_FireBall);
                break;
            case GameManager.SoundState.ENEMY_FIREBALL:
                gamePlayEffectsSource.PlayOneShot(Alien_FireBall);
                break;
            case GameManager.SoundState.FIREGIRL_COMPLETION_SOUND:
                gamePlayEffectsSource.PlayOneShot(firegirl_completion_sound);
                break;
            case GameManager.SoundState.ROCKMAN_COMPLETION_SOUND:
                gamePlayEffectsSource.PlayOneShot(rockman_completion_sound);
                break;
            case GameManager.SoundState.THUNDERMAN_COMPLETION_SOUND:
                gamePlayEffectsSource.PlayOneShot(thunderman_completion_sound);
                break;
        }
    }

    public void setGameLevelSounds(GameManager.SoundState soundState)
    {
        if (soundState == GameManager.SoundState.MENUSOUND)
        {
            this.PlayMenuBGSound();
        }
        else if (soundState == GameManager.SoundState.GAMEPLAYSOUND)
        {
            this.PlayGamePlaySound();
        }
    }

    private void ButtonClickSound()
    {
        gamePlayEffectsSource.PlayOneShot(buttonClickSound);
    }

    private void humanDeathSound()
    {
        gamePlayEffectsSource.PlayOneShot(humanDeath);
    }

    private void playerLastAttack()
    {
        gamePlayEffectsSource.PlayOneShot(playerLastAttackSound);
    }


    public void MuteSound()
    {
        gamePlayEffectsSource.mute = true;
        runSoundSource.mute = true;
        healthSoundSource.mute = true;
    }

    public void UnMuteSound()
    {
        gamePlayEffectsSource.mute = false;
        runSoundSource.mute = false;
        healthSoundSource.mute = false;
    }

    public void MuteMusic()
    {
        GetComponent<AudioSource>().mute = true;
    }

    public void UnMuteMusic()
    {
        GetComponent<AudioSource>().mute = false;
    }

    public void muteMusicExceptEffectSource()
    {
        GetComponent<AudioSource>().mute = true;
        CarEnvSound.mute = true;
        BackgroundSoundSource.mute = true;
        CarEnvSound.mute = true;
        runSoundSource.mute = true;
        healthSoundSource.mute = true;
    }


    private void PlayMenuBGSound()
    {
        this.GetComponent<AudioSource>().clip = menuBGSound;
        this.GetComponent<AudioSource>().Play();
//		this.GetComponent<AudioSource>().volume = 0.1f;
        CarEnvSound.Play();
    }

    private void PlayGamePlaySound()
    {
        this.GetComponent<AudioSource>().clip = gamePlayBGSound;
        this.GetComponent<AudioSource>().Play();
//		this.GetComponent<AudioSource>().volume = 0.4f;
        CarEnvSound.Play();
    }

    private void dontPlaySound()
    {
        this.GetComponent<AudioSource>().Stop();
        CarEnvSound.Stop();
    }

    private void playRainSound()
    {
        rainthunderSoundSource.GetComponent<AudioSource>().clip = rainSound;
        rainthunderSoundSource.GetComponent<AudioSource>().Play();
        this.GetComponent<AudioSource>().volume = 0.3f;
    }

    private void PlayNightBGSound()
    {
        this.GetComponent<AudioSource>().clip = nightBGSound;
        this.GetComponent<AudioSource>().Play();
    }

    public void stopRainSound()
    {
        rainthunderSoundSource.GetComponent<AudioSource>().Stop();
    }

    public void playHealthSound()
    {
        if (!healthSoundSource.isPlaying)
            healthSoundSource.Play();
    }

    public void stopHealthSound()
    {
        healthSoundSource.Stop();
    }

    public void stopRunSound()
    {
        //runSoundSource.Stop();
    }
}