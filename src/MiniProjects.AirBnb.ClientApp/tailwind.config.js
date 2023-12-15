export default {
  content: [
    "./index.html",
    "./src/**/*.{vue,js,ts,jsx,tsx}",
  ],
  darkMode: 'class',
  theme: {
    screens: {
      sm: '545px',
      md: '745px',
      lg: '950px',
      xl: '1440px',
    },
    extend: {
      colors: {
        bgColor: '#f7f7f7',
        bgColorSecondary: '#ffffff',
        bgColorDark: '#21252b',
        bgColorSecondaryDark: '#2c313c',
        borderColor: '#eaeaea',
        borderColorDark: '#333841',
        textPrimary: '#222222',
        textSecondary: '#818181',
        logoSelected: '#000000',
        logoSecondary: '#717171',
        logoAccent: '#dddddd',
        logoPrimary: '#ff385c',
        borderSecondary: '#cccccc',
        defaultBackground: '#ffffff',
      }
    },
  },
  plugins: [],
}