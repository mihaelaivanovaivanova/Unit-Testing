using PackageManager.Commands.Contracts;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;
using System;

namespace PackageManager.Commands
{
    internal class InstallCommand : ICommand
    {
        private IInstaller<IPackage> installer;
        private IPackage package;

        public InstallCommand(IInstaller<IPackage> installer, IPackage package)
        {
            if(installer == null)
            {
                throw new ArgumentNullException();
            }

            if (package == null)
            {
                throw new ArgumentNullException();
            }

            this.installer = installer;
            this.package = package;
            this.installer.Operation = InstallerOperation.Install;
        }

        public IInstaller<IPackage> Installer
        {
            get
            {
                return this.installer;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.installer = value;
            }
        }

        public IPackage Package
        {
            get
            {
                return this.package;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.package = value;
            }
        }

        public void Execute()
        {
            this.installer.PerformOperation(this.package);
        }
    }
}
