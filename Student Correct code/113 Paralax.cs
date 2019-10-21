﻿
    void Awake()
    {
        cam = Camera.main.transform;
    }

    void Start()
    {
        previousCamPos = cam.position;
        scales = new float[_backGrounds.Count];

        for (int i = 0; i < _backGrounds.Count; i++)
        {
            if (_backGrounds[i] != null) scales[i] = _backGrounds[i]._backGround.position.z * -1;
        }
    }

    void Update()
    {
        for (int i = 0; i < _backGrounds.Count; i++)
        {
            if (_backGrounds[i] != null)
            {
                Vector3 parallax = (previousCamPos - cam.position) * scales[i];

                switch (parallaxMode)
                {
                    case Mode.Horizontal:
                        position = new Vector3(_backGrounds[i]._backGround.position.x + parallax.x, 
                            _backGrounds[i]._backGround.position.y, _backGrounds[i]._backGround.position.z);
                        break;
                    case Mode.Vertical:
                        position = new Vector3(_backGrounds[i]._backGround.position.x, 
                            _backGrounds[i]._backGround.position.y + parallax.y, _backGrounds[i]._backGround.position.z);
                        break;
                    case Mode.HorizontalAndVertical:
                        position = new Vector3(_backGrounds[i]._backGround.position.x + parallax.x, 
                            _backGrounds[i]._backGround.position.y + parallax.y, _backGrounds[i]._backGround.position.z);
                        break;
                }

                _backGrounds[i]._backGround.position = Vector3.Lerp(_backGrounds[i]._backGround.position, position, _backGrounds[i]._damping * Time.deltaTime);
            }
        }
        previousCamPos = cam.position;
    }

