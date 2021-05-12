using System;
using System.Collections.Generic;
using System.Text;

namespace Question2.Enonce
{
    public class ServiceClient

    {

        private bool _traitementEnErreur;

        public bool EffectuerTraitement()

        {

            IService1 service1 = new Service1();

            IService2 service2 = new Service2();

            IService3 service3 = new Service3();

            IService4 service4 = new Service4();



            if (service1.TraitementEnSucces())

            {

                if (service2.TraitementEnSucces())

                {

                    if (service3.TraitementEnSucces())

                    {

                        if (service4.TraitementEnSucces())

                        {

                            _traitementEnErreur = true;

                        }

                        else

                        {

                            _traitementEnErreur = false;

                        }

                    }

                    else

                    {

                        _traitementEnErreur = false;

                    }

                }

                else

                {

                    _traitementEnErreur = false;

                }

            }

            else

            {

                _traitementEnErreur = false;

            }



            return _traitementEnErreur;

        }

    }
}
