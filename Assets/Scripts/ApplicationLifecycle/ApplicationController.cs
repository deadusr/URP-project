using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;
using Unity.Netcode;
using Project.ConnectionManagment;
using Project.Gameplay.UI;
using Project.UnityServices.Auth;


namespace Project.ApplicationLifecycle {

    public class ApplicationController : LifetimeScope {
        [SerializeField] NetworkManager m_NetworkManager;
        [SerializeField] ConnectionManager m_ConnectionManager;

        protected override void Configure(IContainerBuilder builder) {
            builder.RegisterComponent(m_ConnectionManager);
            builder.RegisterComponent(m_NetworkManager);

            builder.Register<AuthenticationServiceFacade>(Lifetime.Singleton);
        }

        private void Start() {
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene("MainMenu");
        }
    }

}