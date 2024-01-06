// -- IMPORTS

using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

// -- TYPES

public class VIDEO_VIEW : VisualElement, IDisposable
{
    // -- ATTRIBUTES

    public GameObject
        ParentGameObject;
    public string
        FilePath;
    public bool
        IsPlayed,
        IsLooping;
    public float
        Width,
        Height,
        AspectRatio;
    public VideoPlayer
        Player;
    public RenderTexture
        RenderTexture_;
    public Image
        RenderImage;
    public bool
        IsDisposed;

    // -- CONSTRUCTORS

    public VIDEO_VIEW(
        )
    {
        Player = null;
        RenderTexture_ = null;
        RenderImage = null;
        IsDisposed = false;

        style.overflow = Overflow.Hidden;
    }

    // -- DESTRUCTOR

    ~VIDEO_VIEW(
        )
    {
        ReleaseResources( false );
    }

    // -- OPERATIONS

    public void SetParentGameObject(
        GameObject parent_game_object
        )
    {
        ParentGameObject = parent_game_object;
    }

    // ~~

    public void SetVideo(
        string file_path,
        bool is_played = false,
        bool is_looping = true,
        int width = 1920,
        int height = 1080,
        VideoAspectRatio video_aspect_ratio = VideoAspectRatio.Stretch
        )
    {
        FilePath = file_path;
        IsPlayed = is_played;
        IsLooping = is_looping;
        Width = width;
        Height = height;
        AspectRatio = Width / Height;

        if ( Player == null )
        {
            Player = new GameObject( "VideoPlayer" ).AddComponent<VideoPlayer>();
            Player.transform.SetParent( ParentGameObject.transform );
            Player.source = VideoSource.Url;
            Player.url = FilePath;
            Player.playOnAwake = IsPlayed;
            Player.isLooping = IsLooping;
            Player.aspectRatio = video_aspect_ratio;

            RenderTexture_ = new RenderTexture( width, height, 24 );
            Player.targetTexture = RenderTexture_;

            RenderImage = new Image();
            RenderImage.image = RenderTexture_;
            RenderImage.scaleMode = ScaleMode.ScaleAndCrop;
            RenderImage.style.position = Position.Absolute;
            RenderImage.style.left = 0;
            RenderImage.style.right = 0;
            RenderImage.style.top = 0;
            RenderImage.style.bottom = 0;

            Add( RenderImage );
        }
        else
        {
            Player.source = VideoSource.Url;
        }
    }

    // ~~

    public void Play(
        )
    {
        if ( Player != null )
        {
            Player.Play();
        }
    }

    // ~~

    public void Pause(
        )
    {
        if ( Player != null )
        {
            Player.Pause();
        }
    }

    // ~~

    public void SetTime( double seconds )
    {
        if ( Player != null )
        {
            Player.time = seconds;
        }
    }

    // ~~

    public void Dispose(
        )
    {
        ReleaseResources( true );
        GC.SuppressFinalize( this );
    }

    // ~~

    public void ReleaseResources(
        bool is_disposing
        )
    {
        if ( !IsDisposed )
        {
            if ( is_disposing )
            {
                if ( RenderTexture_ != null )
                {
                    RenderTexture_.Release();
                    RenderTexture_ = null;
                }
            }

            if ( Player != null )
            {
                GameObject.Destroy( Player.gameObject );
                Player = null;
            }

            IsDisposed = true;
        }
    }
}
