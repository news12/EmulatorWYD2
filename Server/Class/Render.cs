using Application.Struct;

namespace Application.Class
{
    public class Render
    {
        public const int View = 22;
        // Atributos
        public object Obj { get; private set; }

        private List<object> Local { get; set; }

        // Construtor
        public Render(object obj)
        {
            Obj = obj;

            Local = new List<object>();
        }

        // Retorna os arredores
        public List<object> GetRender()
        {
            if (Local == null)
            {
                throw new Exception("this.Surrounds == null");
            }

            return Local;
        }

        // Adiciona objeto aos arredores
        public void AddRender(object o)
        {
            if (Local == null)
            {
                throw new Exception("this.Surrounds == null");
            }
            else if (o == null)
            {
                throw new Exception("o == null");
            }

            Local.Add(o);
        }

        // Remove objeto dos arredores
        public void RemoveRender(object o)
        {
            if (Local == null)
            {
                throw new Exception("this.Surrounds == null");
            }
            else if (o == null)
            {
                throw new Exception("o == null");
            }

            Local.Remove(o);
        }

        // Atualiza os arredores
        public void UpdateRender(Action<List<object>> Same, Action<List<object>> Entered, Action<List<object>> Left)
        {
            // Prepara lista pros novos arredores
            List<object> local = new();

            // Gyarda mapa e posição
            Map map = null;
            Coordinate src = null;

            // Lê mapa e posição
            switch (Obj)
            {
                case Client client:
                    {
                        map = client.Map;
                        src = map.GetCoord(SPosition.New(client.Character.LastPosition.X, client.Character.LastPosition.Y));
                        break;
                    }
            }

            // Retorna lista com os arredores novos
            if (map != null)
            {
                for (int x = src.X - View; x <= src.X + View; x++)
                {
                    for (int y = src.Y - View; y <= src.Y + View; y++)
                    {
                        Coordinate coord = map.GetCoord(x, y);

                        if (coord != null)
                        {
                            if (coord.Client != null)
                            {
                                local.Add(coord.Client);
                            }
                        }
                    }
                }
            }

            // Remove valores inválidos
            local.RemoveAll(a => a == null);
            local.Remove(Obj);

            // Retorna listas com objetos novos, iguais e que saíram
            List<object>
                same = Local.Intersect(local).ToList(),
                entered = local.Except(Local).ToList(),
                left = Local.Except(local).ToList();

            // Adiciona este a lista dos que entraram
            entered.ForEach(a =>
            {
                switch (a)
                {
                    case Client client: client.Render.AddRender(Obj); break;
                }
            });

            // Remove este da lista dos que saíram
            left.ForEach(a =>
            {
                switch (a)
                {
                    case Client client: client.Render.RemoveRender(Obj); break;
                }
            });

            // Chama as ações
            Same?.Invoke(same);
            Entered?.Invoke(entered);
            Left?.Invoke(left);

            // Atualiza a lista dos arredores
            Local.Clear();
            Local.AddRange(local);
        }
    }
}