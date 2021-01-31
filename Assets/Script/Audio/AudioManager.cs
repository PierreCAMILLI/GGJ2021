using UnityEngine;

namespace Audio
{
    public class AudioManager : SingletonBehaviour<AudioManager>
    {
        [SerializeField] private AudioSource MenuMusic;

        [SerializeField] private AudioSource GameMusic;

        [SerializeField] private AudioSource JumpSound;

        public void PlayMenuMusic()
        {
            MenuMusic.Play();
        }

        public void StopMenuMusic()
        {
            MenuMusic.Stop();
        }

        public void PlayGameMusic()
        {
            GameMusic.Play();
        }

        public void StopGameMusic()
        {
            GameMusic.Stop();
        }

        public void PlayJumpSound()
        {
            JumpSound.Play();
        }
    }
}
