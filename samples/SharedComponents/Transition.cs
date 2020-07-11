using System;
using System.Linq;

namespace SharedComponents
{
    internal enum TransitionType
    {
        None,
        Fade,
        Slide,
        Scale,
        FadeInScaleOut,
    }

    internal class Transition
    {
        // The CSS handling for these transitions is slightly more complicated that it would be in most real life scenarios because in the demo we need to cater for the transition
        // type and toast position changing dynamically, whereas in reality this is unlikely to happen. So for this demo each transition type has to have its own unique class
        // name, e.g. 'blazored-toast-sample-fade-transition', but in the example markup that we display to the user we just want to display 'blazored-toast' as the class name.

        private static Transition FadeTransition = new Transition(Resources.Transition.FadeTransitionCss, "blazored-toast-sample-fade-transition");
        private static Transition SlideTransition = new Transition(Resources.Transition.SlideTransitionCss, "blazored-toast-sample-slide-transition");
        private static Transition ScaleTransition = new Transition(Resources.Transition.ScaleTransitionCss, "blazored-toast-sample-scale-transition");
        private static Transition FadeInScaleOutTransition = new Transition(Resources.Transition.FadeInScaleOutTransitionCss, "blazored-toast-sample-fade-in-scale-out-transition");

        private string _css;

        public string Css
        {
            get
            {
                // For the purposes of displaying markup, use the generic class name 'blazored-toast':
                return _css != null ? string.Format(_css, "blazored-toast") : null;
            }

            private set
            {
                _css = value;
            }
        }

        public string CssClass { get; private set; }

        public TimeSpan CloseDelay { get; private set; } = TimeSpan.FromMilliseconds(500);

        public Transition(string css, string cssClass)
        {
            Css = css;
            CssClass = cssClass;
        }

        public static Transition GetByType(TransitionType type)
        {
            switch (type)
            {
                case TransitionType.None: return null;
                case TransitionType.Fade: return FadeTransition;
                case TransitionType.Slide: return SlideTransition;
                case TransitionType.Scale: return ScaleTransition;
                case TransitionType.FadeInScaleOut: return FadeInScaleOutTransition;
                default: throw new NotSupportedException($"Transition type is not supported: {type}");
            }
        }

        public static string GetDemoCss()
        {
            return string.Join(Environment.NewLine, Enum.GetValues(typeof(TransitionType))
                .Cast<TransitionType>()
                .Select(tt =>
                {
                    var transition = GetByType(tt);

                    return transition != null
                        // For the purposes of the demo, use unique class names, e.g. 'blazored-toast-sample-fade-transition':
                        ? string.Format(transition._css, transition.CssClass)
                        : null;
                }));
        }
    }
}
